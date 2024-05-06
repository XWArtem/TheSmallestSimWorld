using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button buttonStart;
    [SerializeField] private Image blackTint;

    private void Awake()
    {
        blackTint.color = new Color(0f, 0f, 0f, 0f);
    }

    private void OnEnable()
    {
        buttonStart.onClick.AddListener(StartLevelSceneDelayed);
    }

    private void OnDisable()
    {
        buttonStart.onClick.RemoveListener(StartLevelSceneDelayed);
    }

    private void StartLevelSceneDelayed()
    {
        blackTint.DOFade(1f, 1f).
            OnComplete(StartLevelScene);
    }

    private void StartLevelScene()
    {
        SceneManager.LoadScene(ConstValues.LevelScene);
    }
}