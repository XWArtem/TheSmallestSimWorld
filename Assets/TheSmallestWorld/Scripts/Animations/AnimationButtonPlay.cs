using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AnimationButtonPlay : MonoBehaviour
{
    private RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        StartCoroutine(nameof(PlayButtonAnimation));
    }

    private IEnumerator PlayButtonAnimation()
    {
        while (true)
        {
            rect.DOScale(new Vector2(1.1f, 1.1f), 1f).
                SetEase(Ease.OutElastic, 0.2f);

            yield return new WaitForSeconds(1f + 0.5f);

            rect.DOScale(Vector2.one, 1f).
                SetEase(Ease.OutElastic, 0.2f);

            yield return new WaitForSeconds(1f + 4f);
        }
    }
}