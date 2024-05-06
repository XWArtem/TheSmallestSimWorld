using UnityEngine;

public class PopupShopController : MonoBehaviour
{
    [SerializeField] private AnimationPopup vendorPopup;
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private Transform parentTransform;

    private ShopData data;

    private bool dataLoaded;

    public void Init()
    {
        data = new ShopData();
        FillShopData();
    }

    public void PopupTryShow()
    {
        vendorPopup.Show();
    }

    public void PopupTryHide()
    {
        vendorPopup.Hide();
    }

    private void FillShopData()
    {
        foreach(ItemBase itemBase in data.Items)
        {
            var newItemFrame = Instantiate(shopItemPrefab);
            newItemFrame.transform.SetParent(parentTransform);
            newItemFrame.name = itemBase.Name;
            newItemFrame.GetComponent<ShopItemFrame>().InitFrame(itemBase);
        }


        dataLoaded = true;
    }
}