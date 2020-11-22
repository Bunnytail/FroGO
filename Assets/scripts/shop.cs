using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public Text pointstext;
    public FrogController frog;
    public GameObject buttonBuy;
    public Text textbuy;
    public GameObject buttonEquip;
    private int skin;
    void Start()
    {
        Refresh();
    }
    public void Lewoklik()
    {
        
        skin -= 1;
        if(skin < 0)
        {
            skin = frog.skins.Length - 1;
        }
        frog.SetSkin(skin);
        Refresh();
    }
    public void Prawoklik()
    {
        
        skin += 1;
        if (skin >= frog.skins.Length)
        {
            skin = 0;
        }
        frog.SetSkin(skin);
        Refresh();
    }

    public void Buy()
    {
        string skinname = "skin_" + skin;
        int price = skin * 2;
        int points = PlayerPrefs.GetInt("points", 0);
        if (points >= price)
        {
            points -= price;
            PlayerPrefs.SetInt(skinname, 1);
            PlayerPrefs.SetInt("points", points);
            Refresh();
        }
    }

    public void Equip()
    {
        PlayerPrefs.SetInt("skin", skin);

    }

    public void Refresh()
    {

        string skinname = "skin_" + skin;
        int price = skin * 2;
        bool bought = PlayerPrefs.GetInt(skinname, 0) == 1;

        pointstext.text = "points: " + PlayerPrefs.GetInt("points", 0);
        textbuy.text = "BUY FOR " + price;
        if (skin == 0 || bought)
        {
            buttonBuy.SetActive(false);
            buttonEquip.SetActive(true);
        }
        else
        {
            buttonBuy.SetActive(true);
            buttonEquip.SetActive(false);
        }
    }

}
