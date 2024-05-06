using DG.Tweening;
using UnityEngine;

public class AnimationPopup : MonoBehaviour
{
    private float startAnchY;
    private float endAnchY;
    private RectTransform rect;

    [SerializeField] private RectTransform startAnchPos;

    private bool isShown;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        endAnchY = rect.anchoredPosition.y;
        startAnchY = startAnchPos.anchoredPosition.y;

        isShown = false;
    }

    private void Start()
    {
        gameObject.SetActive(true);
        this.ActionDelayed(0.1f, () => rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, startAnchPos.anchoredPosition.y)); // unity bug here. delay needed to work
    }

    public void Show()
    {
        if (!isShown)
        {
            isShown = !isShown;
            gameObject.SetActive(true);
            rect.DOAnchorPosY(endAnchY, 0.8f);
        }
    }

    public void Hide()
    {
        if (isShown)
        {
            isShown = !isShown;
            rect.DOAnchorPosY(startAnchY, 0.8f).
                OnComplete(() => gameObject.SetActive(isShown));
        }
    }
}
