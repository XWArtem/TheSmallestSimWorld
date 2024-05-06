using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemFrame : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI itemLabel;
    [SerializeField] private Button actionButton;
    [SerializeField] private TextMeshProUGUI actionButtonText;

    private ItemBase itemBase;

    private void OnEnable()
    {
        StaticActions.OnItemsChanged += UpdateFrameInfo;
        actionButton.onClick.AddListener(() => BuyItem(itemBase.Cost, itemBase.ID));
    }

    public void InitFrame(ItemBase itemBase)
    {
        this.itemBase = itemBase;
        itemImage.sprite = Resources.Load<Sprite>(ConstValues.ItemSpritesPath + "/" + itemBase.SpriteName);
        UpdateFrameInfo();
    }

    private void UpdateFrameInfo()
    {
        costText.text = $"{itemBase.Cost}";
        itemLabel.text = $"{itemBase.Name}";

        actionButton.interactable = ButtonBuyAvailable(itemBase.Cost, itemBase.ID);
        actionButtonText.text = !UserInGameData.Instance.ItemIsAvailable(itemBase.ID) ? "Buy" : "Bought";
        
    }

    private void OnDisable()
    {
        actionButton.onClick.RemoveAllListeners();
        StaticActions.OnItemsChanged -= UpdateFrameInfo;
    }

    private bool ButtonBuyAvailable(int cost, int itemID)
    {
        return UserInGameData.Instance.Coins >= cost && !UserInGameData.Instance.ItemIsAvailable(itemID);
    }

    private void BuyItem(int cost, int itemID)
    {
        if (UserInGameData.Instance.Coins >= cost)
        {
            AudioManager.instance?.PlayClipByIndex(2);
            UserInGameData.Instance.Coins -= cost;
            UserInGameData.Instance.SetItemAvailability(itemID, true);
        }
    }
}
