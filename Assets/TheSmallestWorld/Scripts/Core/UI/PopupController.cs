using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] private PopupVendor vendor;


    private void OnEnable()
    {
        StaticActions.OnVendorCanvasShow += VendorTryShow;
        StaticActions.OnVendorCanvasHide += VendorTryHide;
    }

    private void OnDisable()
    {
        StaticActions.OnVendorCanvasShow -= VendorTryShow;
        StaticActions.OnVendorCanvasHide -= VendorTryHide;
    }

    private void VendorTryShow()
    {
        vendor.PopupTryShow();
    }

    private void VendorTryHide()
    {
        vendor.PopupTryHide();
    }
}
