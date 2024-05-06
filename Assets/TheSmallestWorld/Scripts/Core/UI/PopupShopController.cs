using System.Collections.Generic;
using UnityEngine;

public class PopupShopController : MonoBehaviour
{
    [SerializeField] private AnimationPopup vendorPopup;
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private Transform parentTransform;

    private List<ShopItemFrame> shopItemFrames = new List<ShopItemFrame>();

    private ShopData data;

    private bool dataLoaded;

    public void Init()
    {
        data = new ShopData();
        FillShopData();
    }

    public void PopupTryShow()
    {
        for (int i = 0; i < shopItemFrames.Count; i++)
        {
            Destroy(shopItemFrames[i].gameObject);
        }
        shopItemFrames.Clear();
        FillShopData();

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
            shopItemFrames.Add(newItemFrame.GetComponent<ShopItemFrame>());
        }

        dataLoaded = true;
    }
}