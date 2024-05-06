using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrashCanItemFrame : MonoBehaviour
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
        actionButton.onClick.AddListener(() => SellItem(itemBase.Cost, itemBase.ID));
    }

    public void InitFrame(ItemBase itemBase)
    {
        this.itemBase = itemBase;
        itemImage.sprite = Resources.Load<Sprite>(ConstValues.ItemSpritesPath + "/" + itemBase.SpriteName);
        UpdateFrameInfo();
    }

    public void UpdateFrameInfo()
    {
        costText.text = $"{itemBase.Cost}";
        itemLabel.text = $"{itemBase.Name}";

        actionButton.interactable = ButtonSellAvailable(itemBase.ID);
        actionButtonText.text = UserInGameData.Instance.ItemIsAvailable(itemBase.ID) ? "Sell" : "Sold";
    }

    private void OnDisable()
    {
        actionButton.onClick.RemoveAllListeners();
        StaticActions.OnItemsChanged -= UpdateFrameInfo;
    }

    private bool ButtonSellAvailable(int itemID)
    {
        return UserInGameData.Instance.ItemIsAvailable(itemID);
    }

    private void SellItem(int cost, int itemID)
    {
        if (UserInGameData.Instance.ItemIsAvailable(itemID))
        {
            AudioManager.instance?.PlayClipByIndex(2);
            UserInGameData.Instance.Coins += cost/2;
            UserInGameData.Instance.SetItemAvailability(itemID, false);
            if (UserInGameData.Instance.WeaponSelectedIndex == itemID)
            {
                UserInGameData.Instance.WeaponSelectedIndex = 0;
            }
            StaticActions.OnItemSelectedChanged?.Invoke();

            var rect = actionButton.GetComponent<RectTransform>();
            rect.DOScale(0.8f, 0.2f).
                SetEase(Ease.OutSine, 0.3f).
                OnComplete(() => rect.DOScale(1f, 0.2f).
                SetEase(Ease.OutSine, 0.3f));
        }
    }
}
