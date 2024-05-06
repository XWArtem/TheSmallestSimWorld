using System;
using UnityEngine;

public class MainHero : MonoBehaviour
{
    private InputHandButton inputHandButton;
    private Action actionCaptured;

    private void OnEnable()
    {
        StaticActions.OnHandButtonClicked += ActionCapturedInvoke;
    }

    private void OnDisable()
    {
        StaticActions.OnHandButtonClicked -= ActionCapturedInvoke;
    }

    public void Init(InputHandButton inputHandButton)
    {
        this.inputHandButton = inputHandButton;
    }

    public void SetInteractionStatus(IInteractable sender, bool interactionAvailable, Action callback)
    {
        inputHandButton.ChangeHandButtonState(interactionAvailable);
        actionCaptured = callback;
    }

    private void ActionCapturedInvoke()
    {
        if (actionCaptured == null)
        {
            Debug.LogWarning($"Action hasn't been captured! Check it in {gameObject.name}");
        }
        else
        {
            actionCaptured.Invoke();
        }
    }
}
