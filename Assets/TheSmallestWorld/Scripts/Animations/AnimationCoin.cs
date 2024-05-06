using DG.Tweening;
using UnityEngine;

public class AnimationCoin : MonoBehaviour
{
    private int coinsValue;

    private void OnEnable()
    {
        coinsValue = Random.Range(5, 25);
        Expand();
    }

    private void Shrink()
    {
        transform.DOScale(new Vector3(0.5f, 0.5f), 0.6f).
            SetEase(Ease.InBounce, 0.4f).
            OnComplete(Expand);
    }

    private void Expand()
    {
        transform.DOScale(new Vector3(0.6f, 0.6f), 0.6f).
            SetEase(Ease.InBounce, 0.4f).
            OnComplete(Shrink);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ConstValues.PlayerTag))
        {
            UserInGameData.Instance.Coins += coinsValue;
            gameObject.SetActive(false);
        }
    }
}
