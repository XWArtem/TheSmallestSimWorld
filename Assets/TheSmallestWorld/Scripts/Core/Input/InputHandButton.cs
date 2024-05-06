using UnityEngine;
using UnityEngine.UI;

public class InputHandButton : MonoBehaviour
{
    [SerializeField] private Button handButton;

    private void OnEnable()
    {
        handButton.onClick.AddListener(Interact);
    }

    private void OnDisable()
    {
        handButton.onClick.RemoveListener(Interact);
    }

    private void Interact()
    {
        Debug.Log("Interact");
        StaticActions.OnHandButtonClicked?.Invoke();
    }

    public void ChangeHandButtonState(bool setActive)
    {
        handButton.interactable = setActive;
    }
}
