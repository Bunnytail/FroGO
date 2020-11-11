using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public Text pointstext;
    public FrogController frog;
    void Start()
    {
        pointstext.text = "points: " + PlayerPrefs.GetInt("points", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lewoklik()
    {
        int skin = PlayerPrefs.GetInt("skin", 0);
        skin -= 1;
        if(skin < 0)
        {
            skin = frog.skins.Length - 1;
        }
        frog.SetSkin(skin);
        PlayerPrefs.SetInt("skin", skin);
    }
    public void Prawoklik()
    {
        int skin = PlayerPrefs.GetInt("skin", 0);
        skin += 1;
        if (skin >= frog.skins.Length)
        {
            skin = 0;
        }
        frog.SetSkin(skin);
        PlayerPrefs.SetInt("skin", skin);
    }
}
