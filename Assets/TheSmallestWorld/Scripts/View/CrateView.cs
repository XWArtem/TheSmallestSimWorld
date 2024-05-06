using UnityEngine;

public class CrateView : MonoBehaviour
{
    [SerializeField] private bool isCompulsory;
    [SerializeField] private Sprite crateOptionOne, crateOptionTwo;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = (Random.Range(0, 2)&1) == 0 ? crateOptionOne : crateOptionTwo;
        gameObject.SetActive(isCompulsory || (Random.Range(0, 2) & 1) == 0 ? true : false);
    }
}
