using System;
using System.Collections.Generic;
using UnityEngine;

public class MainHero : MonoBehaviour
{
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;
    [SerializeField] private List<Sprite> weaponSprites;
    private InputHandButton inputHandButton;
    private Action actionCaptured;

    private void OnEnable()
    {
        StaticActions.OnHandButtonClicked += ActionCapturedInvoke;
        StaticActions.OnItemSelectedChanged += UpdateWeaponView;
        UpdateWeaponView();
    }

    private void OnDisable()
    {
        StaticActions.OnHandButtonClicked -= ActionCapturedInvoke;
        StaticActions.OnItemSelectedChanged -= UpdateWeaponView;
    }

    public void Init(InputHandButton inputHandButton)
    {
        this.inputHandButton = inputHandButton;
    }

    private void UpdateWeaponView()
    {
        weaponSpriteRenderer.sprite = weaponSprites[UserInGameData.Instance.ItemSelected];
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
