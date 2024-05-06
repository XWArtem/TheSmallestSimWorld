using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    public Sprite onSound, onMusic, offSound, offMusic;
    [HideInInspector] public Button soundButton;
    [HideInInspector] public Button musicButton;
    [HideInInspector] public Slider musicSlider;
    [HideInInspector] public Slider soundSlider;
    private Image soundImage, musicImage;
    public event Action ChangeSoundStateCallback;
    private UserInGameData data;
    public AudioClip[] clips;
    public AudioSource SFX;
    public AudioSource Music;
    public AudioClip[] musics;

    public void PlayMusicByIndex(int clipIndex)
    {
        if (!UserInGameData.Instance.Sound) return;
        if (clipIndex > musics.Length - 1 || musics[clipIndex] == null)
        {
            Debug.LogError(
                $"DemoAudioManager.PlayClipByIndex(): index [{clipIndex}] more than clips array lenght or clip with index [{clipIndex}] is null");
            return;
        }
        Music.clip = musics[clipIndex];
        Music.Play();
       
    }
    public void PlayClipByIndex(int clipIndex) {
        if (!UserInGameData.Instance.Sound) return;
        if (clipIndex > clips.Length - 1 || clips[clipIndex] == null) {
            Debug.LogError(
                $"DemoAudioManager.PlayClipByIndex(): index [{clipIndex}] more than clips array lenght or clip with index [{clipIndex}] is null");
            return;
        }

        SFX.PlayOneShot(clips[clipIndex]);
    }

    public void PlayClipByName(string clipName) {
        if (!UserInGameData.Instance.Sound) return;
        var clip = clips.FirstOrDefault(x => x.name == clipName);
        {
            if (clip) {
                SFX.PlayOneShot(clip);
            } else {
                Debug.LogError($"DemoAudioManager.PlayClipByIndex(): Clip with name [{clipName}] doesn't exist");
            }
        }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
            return;
        }

      
        data = UserInGameData.Instance;
    }

    public void UpdateSoundButton() {
        soundImage = soundButton.GetComponent<Image>();
        soundButton.onClick.AddListener(ChangeSoundState);
    }

    public void UpdateMusicButton() {
        musicImage = musicButton.GetComponent<Image>();
        musicButton.onClick.AddListener(ChangeMusicState);
    }

    public void UpdateMusicSlider() {
        musicSlider.onValueChanged.AddListener(delegate { CheckAllSoundsState(); });
    }

    public void UpdateSoundSlider() {
        soundSlider.onValueChanged.AddListener(delegate { CheckAllSoundsState(); });
    }


    private void ChangeSoundState()
    {
        data.Sound = !data.Sound;
        CheckAllSoundsState();
    }

    private void ChangeMusicState()
    {
        data.Music = !data.Music;
        CheckAllSoundsState();
    }

    public void CheckAllSoundsState()
    {
        if (musicSlider != null)
        {
            UserInGameData.Instance.MusicVolume = musicSlider.value;
        }

        if (soundSlider != null)
        {
            UserInGameData.Instance.SoundVolume = soundSlider.value;
        }
        if (soundImage != null) soundImage.sprite = data.Sound ? onSound : offSound;
        if (musicImage != null) musicImage.sprite = data.Music ? onMusic : offMusic;
        ChangeSoundStateCallback?.Invoke();
    }
}