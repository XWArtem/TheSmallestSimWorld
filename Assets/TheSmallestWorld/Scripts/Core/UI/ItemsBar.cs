using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsBar : MonoBehaviour
{
    private ShopData data;
    [SerializeField] private List<Image> images;

    //[SerializeField] private Image axeImage;
    //[SerializeField] private Image clubImage;
    //[SerializeField] private Image staffImage;

    private Color colorAvailable = new Color(1f, 1f, 1f, .5f);
    private Color colorDisabled = new Color(1f, 1f, 1f, 0f);
    private Color colorSelected = Color.white;

    private void OnEnable()
    {
        data = new ShopData();
        StaticActions.OnItemsChanged += UpdateItemBarView;
        StaticActions.OnItemSelectedChanged += UpdateItemBarView;
        UpdateItemBarView();
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
                if (i == UserInGameData.Instance.ItemSelected)
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
        UserInGameData.Instance.ItemSelected = index;
    }
}
