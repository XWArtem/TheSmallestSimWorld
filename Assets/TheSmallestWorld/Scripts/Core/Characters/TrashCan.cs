using UnityEngine;
using System;

public class TrashCan : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionArea interactionArea;
    private MainHero mainHero;

    public Action trashCanAction;

    public void Init(MainHero mainHero)
    {
        this.mainHero = mainHero;
    }

    private void Awake()
    {
        trashCanAction = CallForTrashCan;
        interactionArea.Init(this);
    }

    public void SetInteractactionStatus(bool interactionAvailable)
    {
        if (!interactionAvailable)
        {
            CallForShopUIHide();
        }
        mainHero.SetInteractionStatus(this, interactionAvailable, trashCanAction);
    }

    private void CallForTrashCan()
    {
        StaticActions.OnTrashCanShow?.Invoke();
    }

    public void CallForShopUIHide()
    {
        StaticActions.OnTrashCanHide?.Invoke();
    }
}
