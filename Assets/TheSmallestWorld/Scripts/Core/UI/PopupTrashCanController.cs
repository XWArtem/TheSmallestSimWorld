using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTrashCanController : MonoBehaviour
{
    [SerializeField] private AnimationPopup trashCanPopup;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform parentTransform;

    [SerializeField] private GameObject spiderWebDecorative;

    private List<TrashCanItemFrame> trashCanItemFrames = new List<TrashCanItemFrame>();

    private ShopData data;

    //private bool dataLoaded;

    private void Awake()
    {
        data = new ShopData();
    }
    
    private void OnEnable()
    {
        FillTrashCanData();
    }

    public void PopupTryShow()
    {
        for(int i = 0; i < trashCanItemFrames.Count; i++)
        {
            Destroy(trashCanItemFrames[i].gameObject);
        }
        trashCanItemFrames.Clear();
        FillTrashCanData();
        spiderWebDecorative.SetActive(trashCanItemFrames.Count == 0);

        trashCanPopup.Show();
    }

    public void PopupTryHide()
    {
        trashCanPopup.Hide();
    }

    private void FillTrashCanData()
    {
        for (int i = 0; i< data.Items.Count; i++)
        {
            if (UserInGameData.Instance.ItemIsAvailable(i))
            {
                var newItemFrame = Instantiate(itemPrefab);
                newItemFrame.transform.SetParent(parentTransform);
                newItemFrame.name = data.Items[i].Name;
                newItemFrame.GetComponent<TrashCanItemFrame>().InitFrame(data.Items[i]);
                trashCanItemFrames.Add(newItemFrame.GetComponent<TrashCanItemFrame>());
            }
        }


        //dataLoaded = true;
    }
}
