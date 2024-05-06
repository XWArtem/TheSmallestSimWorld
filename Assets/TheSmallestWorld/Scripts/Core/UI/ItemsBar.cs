using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsBar : MonoBehaviour
{
    private ShopData data;
    [SerializeField] private List<Image> images;

    private Color colorAvailable = new Color(1f, 1f, 1f, .5f);
    private Color colorDisabled = new Color(1f, 1f, 1f, 0f);
    private Color colorSelected = Color.white;

    private void OnEnable()
    {
        data = new ShopData();

        CheckAnyWeaponAvailability();

        StaticActions.OnItemsChanged += UpdateItemBarView;
        StaticActions.OnItemSelectedChanged += UpdateItemBarView;
        UpdateItemBarView();
    }

    private void CheckAnyWeaponAvailability()
    {
        for (int i = 0; i < data.Items.Count; i++)
        {
            if (UserInGameData.Instance.ItemIsAvailable(i))
            {
                return;
            }
        }
        UserInGameData.Instance.AnyWeaponEquipped = false;
    }

    private void OnDisable()
    {
        StaticActions.OnItemsChanged -= UpdateItemBarView;
        StaticActions.OnItemSelectedChanged -= UpdateItemBarView;
    }

    private void UpdateItemBarView()
    {
        for (int i = 0; i < images.Count; i++)
        {
            images[i].sprite = Resources.Load<Sprite>(ConstValues.ItemSpritesPath + "/" + data.Items[i].SpriteName);
            if (UserInGameData.Instance.ItemIsAvailable(i))
            {
                images[i].color = colorAvailable;
                if (i == UserInGameData.Instance.WeaponSelectedIndex && UserInGameData.Instance.AnyWeaponEquipped)
                {
                    images[i].color = colorSelected;
                }
            }
            else
            {
                images[i].color = colorDisabled;
            }
        }
    }

    public void SelectItem(int index)
    {
        if (UserInGameData.Instance.ItemIsAvailable(index))
        {
            UserInGameData.Instance.AnyWeaponEquipped = true;
            UserInGameData.Instance.WeaponSelectedIndex = index;
        }
    }
}
