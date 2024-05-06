using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSceneController : MonoBehaviour
{
    [SerializeField] private Image blackTint;

    public void Init()
    {
        blackTint.raycastTarget = false;
        blackTint.color = new Color(0f, 0f, 0f, 1f);
        blackTint.DOFade(0f, 1.2f).
            OnComplete(() => blackTint.gameObject.SetActive(false));
    }
}
