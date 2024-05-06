using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum componentType {
    Sound,
    Music,
    SoundButton,
    MusicButton,
    MusicSlider,
    SoundSlider
}

public class AudioController : MonoBehaviour {
    private AudioManager manager;
    private AudioSource[] srcs;
    private bool isMusic;
    public componentType type;

    private void Start() {
        manager = AudioManager.instance;
        CheckControllerState();
    }

    private void CheckControllerState() {
        switch (type) {
            case componentType.SoundButton: {
                manager.soundButton = GetComponent<Button>();
                manager.UpdateSoundButton();
                manager.CheckAllSoundsState();
                break;
            }
            case componentType.MusicButton: {
                manager.musicButton = GetComponent<Button>();
                manager.UpdateMusicButton();
                manager.CheckAllSoundsState();
                break;
            }
            case componentType.MusicSlider:
            {
                manager.musicSlider = GetComponent<Slider>();
                manager.musicSlider.value = UserInGameData.Instance.MusicVolume;
                manager.UpdateMusicSlider();
                break;
            }
            case componentType.SoundSlider:
            {
                manager.soundSlider = GetComponent<Slider>();
                manager.soundSlider.value = UserInGameData.Instance.SoundVolume;
                manager.UpdateSoundSlider();
                break;
            }
            
            case componentType.Sound: {
                srcs = GetComponents<AudioSource>();
                foreach (var src in srcs) {
                    src.mute = !UserInGameData.Instance.Sound;
                    src.volume = UserInGameData.Instance.SoundVolume;
                }

                manager.ChangeSoundStateCallback += CheckSoundState;
                break;
            }
            case componentType.Music: {
                srcs = GetComponents<AudioSource>();
                foreach (var src in srcs) {
                    src.mute = !UserInGameData.Instance.Music;
                    src.volume = UserInGameData.Instance.MusicVolume;
                }

                manager.ChangeSoundStateCallback += CheckSoundState;
                break;
            }
        }
    }

    private void OnDestroy() {
        if (type == componentType.MusicButton || type == componentType.SoundButton) return;
       if (manager == null) manager = AudioManager.instance;
       manager.ChangeSoundStateCallback -= CheckSoundState;
    }

    private void CheckSoundState() {
        if (type == componentType.Music) {
            foreach (var src in srcs) {
                src.mute = !UserInGameData.Instance.Music;
                src.volume = UserInGameData.Instance.MusicVolume;
            }
        }


        if (type == componentType.Sound) {
            foreach (var src in srcs) {
                src.mute = !UserInGameData.Instance.Sound;
                src.volume = UserInGameData.Instance.SoundVolume;
            }
        }

    }
}