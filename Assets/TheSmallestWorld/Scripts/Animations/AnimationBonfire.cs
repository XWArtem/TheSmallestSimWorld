using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationBonfire : MonoBehaviour
{
    [SerializeField] private Sprite frameOne, frameTwo;

    private RectTransform rect;

    private Image image;
    private WaitForSeconds waitTick = new WaitForSeconds(0.1f);
    private int frame = 1;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        StartCoroutine(nameof(BonfireAnimation));
    }

    private IEnumerator BonfireAnimation()
    {
        while (true)
        {
            if (frame == 1)
            {
                frame = 2;
                image.sprite = frameTwo;
            }
            else
            {
                frame = 1;
                image.sprite = frameOne;
                rect.localScale = new Vector2(rect.localScale.x * -1f, rect.localScale.y);
            }
            yield return waitTick;
        }
    }
}
