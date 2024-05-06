using UnityEngine;

public class PopupVendor : MonoBehaviour
{
    [SerializeField] private AnimationPopup vendorPopup;

    public void PopupTryShow()
    {
        vendorPopup.Show();
    }

    public void PopupTryHide()
    {
        vendorPopup.Hide();
    }
}