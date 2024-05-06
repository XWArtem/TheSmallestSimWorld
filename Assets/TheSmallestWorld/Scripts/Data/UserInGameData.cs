// This script is my commonly used one to hold data. Relatively quick in development, used for small projects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using System;

public class UserInGameData : MonoBehaviour
{
    public static UserInGameData instance;

    public static UserInGameData Instance
    {
        get 
        { 
            instance ??= new UserInGameData();
            return instance;
        }
    }

    public bool AnyWeaponEquipped
    {
        get => bool.Parse(PlayerPrefs.GetString("AnyItemEquipped", "false"));
        set => PlayerPrefs.SetString("AnyItemEquipped", value.ToString());
    }

    public int WeaponSelectedIndex
    {
        get => PlayerPrefs.GetInt("ItemSelected", 0);
        set
        {
            PlayerPrefs.SetInt("ItemSelected", value);
            StaticActions.OnItemSelectedChanged?.Invoke();
        }
    }

    public int Coins
    {
        get => PlayerPrefs.GetInt("CoinsData", 0);
        set
        {
            PlayerPrefs.SetInt("CoinsData", value);
            StaticActions.OnCoinsValueChanged?.Invoke();
        }
    }

    public bool Sound
    {
        get => bool.Parse(PlayerPrefs.GetString("sound", "true"));
        set => PlayerPrefs.SetString("sound", value.ToString());
    }

    public bool Music
    {
        get => bool.Parse(PlayerPrefs.GetString("music", "true"));
        set => PlayerPrefs.SetString("music", value.ToString());
    }
    public float MusicVolume
    {
        get => PlayerPrefs.GetFloat("musicVolume", .5f);
        set => PlayerPrefs.SetFloat("musicVolume", value);
    }
    public float SoundVolume
    {
        get => PlayerPrefs.GetFloat("soundVolume", .5f);
        set => PlayerPrefs.SetFloat("soundVolume", value);
    }

    private string ItemsAvailablityPrefs
    {
        get => PlayerPrefs.GetString("ItemsAvailablityPrefs", "false, false, false"); 
        set => PlayerPrefs.SetString("ItemsAvailablityPrefs", value);
    }

    public bool ItemIsAvailable(int itemID)
    {
        string[] dict = ItemsAvailablityPrefs.Split(',');
        return bool.Parse(dict[itemID]);
    }

    public void SetItemAvailability(int itemID, bool newState)
    {
        string[] dict = ItemsAvailablityPrefs.Split(',');
        dict[itemID] = newState.ToString();
        StringBuilder sb = new StringBuilder();
        foreach (string item in dict)
        {
            sb.Append(item + ",");
        }
        sb.Remove(sb.Length - 1, 1); // to get rid of the last ','
        ItemsAvailablityPrefs = sb.ToString();

        StaticActions.OnItemsChanged?.Invoke();
    }
}
