using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] private PopupShopController vendor;
    [SerializeField] private PopupTrashCanController trashCan;


    private void OnEnable()
    {
        StaticActions.OnVendorCanvasShow += VendorTryShow;
        StaticActions.OnVendorCanvasHide += VendorTryHide;

        StaticActions.OnTrashCanShow += TrashCanTryShow;
        StaticActions.OnTrashCanHide += TrashCanTryHide;
    }

    private void OnDisable()
    {
        StaticActions.OnVendorCanvasShow -= VendorTryShow;
        StaticActions.OnVendorCanvasHide -= VendorTryHide;

        StaticActions.OnTrashCanShow -= TrashCanTryShow;
        StaticActions.OnTrashCanHide -= TrashCanTryHide;
    }

    private void VendorTryShow()
    {
        vendor.PopupTryShow();
    }

    private void VendorTryHide()
    {
        vendor.PopupTryHide();
    }

    private void TrashCanTryShow()
    {
        trashCan.PopupTryShow();
    }

    private void TrashCanTryHide()
    {
        trashCan.PopupTryHide();
    }
}
