using System;
using System.Collections;
using System.Collections.Generic;
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
        shopCallDelegate = CallForShopUI;
        shopAction = CallForShopUI;

        interactionArea.Init(this);
    }

    public void SetInteractactionStatus(bool interactionAvailable)
    {
        mainHero.SetInteractionStatus(this, interactionAvailable, shopAction);

        // hello or bye animation
    }

    private void CallForShopUI()
    {
        Debug.Log("Call for shop");
        StaticActions.OnVendorCanvasShow?.Invoke();
    }
}
