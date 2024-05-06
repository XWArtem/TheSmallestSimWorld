using System;
using UnityEngine;

public class Vendor : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionArea interactionArea;
    private MainHero mainHero;
    public delegate void InteractionDelegate();
    public InteractionDelegate shopCallDelegate;

    public Action shopAction;

    public void Init(MainHero mainHero)
    {
        this.mainHero = mainHero;
    }

    private void Awake()
    {
        shopCallDelegate = CallForShopUIShow;
        shopAction = CallForShopUIShow;
        interactionArea.Init(this);
    }

    public void SetInteractactionStatus(bool interactionAvailable)
    {
        if (!interactionAvailable)
        {
            CallForShopUIHide();
        }
        mainHero.SetInteractionStatus(this, interactionAvailable, shopAction);

        // hello or bye animation
    }

    private void CallForShopUIShow()
    {
        StaticActions.OnVendorCanvasShow?.Invoke();
    }

    public void CallForShopUIHide()
    {
        StaticActions.OnVendorCanvasHide?.Invoke();
    }
}
