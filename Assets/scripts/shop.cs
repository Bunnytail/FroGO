using System.Collections;
using System.Collections.Generic;
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
    public AudioSource buySound;
    public AudioSource moneySound;
    public AudioSource buttonSound;

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
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            buttonSound.Play();
        }
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
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            buttonSound.Play();
        }
    }

    public void Buy()
    {
        string skinname = "skin_" + skin;
        int price = 3+ skin * 12;
        int points = PlayerPrefs.GetInt("points", 0);
        if (points >= price)
        {
            if(PlayerPrefs.GetInt("sound_on", 1) == 1)
            {
                buySound.Play();
                moneySound.Play();
            }
            points -= price;
            PlayerPrefs.SetInt(skinname, 1);
            PlayerPrefs.SetInt("points", points);
            Refresh();
        }
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            buttonSound.Play();
        }
    }

    public void Equip()
    {
        PlayerPrefs.SetInt("skin", skin);
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            buttonSound.Play();
            buySound.Play();
        }

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
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            buttonSound.Play();
        }
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
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            buttonSound.Play();
        }
    }

    public void Buyhat()
    {
        string skinname = "hat_" + hat;
        int price = 2+ hat * 8;
        int points = PlayerPrefs.GetInt("points", 0);
        if (points >= price)
        {
            if(PlayerPrefs.GetInt("sound_on", 1) == 1)
            {
                buySound.Play();
                moneySound.Play();
            }
            points -= price;
            PlayerPrefs.SetInt(skinname, 1);
            PlayerPrefs.SetInt("points", points);
            Refresh();
            Equiphat();
        }
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            buttonSound.Play();
        }
    }

    public void Equiphat()
    {
        PlayerPrefs.SetInt("hat", hat);
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            buySound.Play();
            buttonSound.Play();
        }

    }


    public void Refresh()
    {
        string skinname = "skin_" + skin;
        int price = 3+ skin * 12;
        bool bought = PlayerPrefs.GetInt(skinname, 0) == 1;

        pointstext.text = "points: " + PlayerPrefs.GetInt("points", 0);
        textbuy.text = "" + price;
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
        int pricehat = 2+ hat * 8;
        bool boughthat = PlayerPrefs.GetInt(hatname, 0) == 1;

       
        textbuyhat.text = "" + pricehat;
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
