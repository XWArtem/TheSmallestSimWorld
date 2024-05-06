using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private List<GameObject> coinsImages;
    private int coinsViewStep = 10;


    private void OnEnable()
    {
        StaticActions.OnCoinsValueChanged += UpdateCoinsInfo;
    }

    private void OnDisable()
    {
        StaticActions.OnCoinsValueChanged -= UpdateCoinsInfo;
    }

    public void Init()
    {
        UpdateCoinsInfo();
    }

    public void UpdateCoinsInfo()
    {
        coinsText.text = $"{UserInGameData.Instance.Coins}";

        for (int i = 0; i < coinsImages.Count; i++)
        {
            coinsImages[i].SetActive(UserInGameData.Instance.Coins >= Mathf.Pow(coinsViewStep, i) - 1);
        }
    }
}