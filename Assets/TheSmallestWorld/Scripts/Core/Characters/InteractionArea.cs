using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    private IInteractable parent;

    private MainHero mainHero;

    public void Init(IInteractable parent)
    {
        this.parent = parent;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ConstValues.PlayerTag))
        {
            Debug.Log("Let's trade");
            if (mainHero == null)
            {
                if (collision.TryGetComponent<MainHero>(out mainHero))
                {
                    parent.SetInteractactionStatus(true);
                }
            }
            else
            {
                parent.SetInteractactionStatus(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ConstValues.PlayerTag))
        {
            if (mainHero != null)
            {
                parent.SetInteractactionStatus(false);
            }
            else if (collision.TryGetComponent<MainHero>(out mainHero))
            {
                parent.SetInteractactionStatus(false);
            }
        }
    }
}
