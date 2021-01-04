using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public Text pointstext;
    public FrogControllerNew frog;
    public GameObject buttonBuy;
    public GameObject buttonBuyhat;
    public GameObject buttonEquiphat;
    public Text textbuyhat;
    public Text textbuy;
    public GameObject buttonEquip;
    private int skin;
    private int hat;
    void Start()
    {
        Refresh();

        frog.SetHat(hat);
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

    public void Lewoklikhat()
    {

        hat -= 1;
        if (hat < 0)
        {
            hat = frog.hats.Length - 1;
        }
        frog.SetHat(hat);
        Refresh();
    }
    public void Prawoklikhat()
    {

        hat += 1;
        if (hat >= frog.hats.Length)
        {
            hat = 0;
        }
        frog.SetHat(hat);
        Refresh();
    }

    public void Buyhat()
    {
        string skinname = "hat_" + hat;
        int price = 2+ hat * 2;
        int points = PlayerPrefs.GetInt("points", 0);
        if (points >= price)
        {
            points -= price;
            PlayerPrefs.SetInt(skinname, 1);
            PlayerPrefs.SetInt("points", points);
            Refresh();
            Equiphat();
        }
    }

    public void Equiphat()
    {
        PlayerPrefs.SetInt("hat", hat);

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

        string hatname = "hat_" + hat;
        int pricehat = 2+ hat * 2;
        bool boughthat = PlayerPrefs.GetInt(hatname, 0) == 1;

       
        textbuyhat.text = "BUY FOR " + pricehat;
        if (boughthat)
        {
            buttonBuyhat.SetActive(false);
            buttonEquiphat.SetActive(true);
        }
        else
        {
            buttonBuyhat.SetActive(true);
            buttonEquiphat.SetActive(false);
        }
    }



}
