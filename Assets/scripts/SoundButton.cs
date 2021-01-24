using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite on;
    public Sprite off;
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();
        Refresh();
    }

    void Refresh()
    {
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            image.sprite = on;
        }
        else
        {
            image.sprite = off;
        }
    }

    public void Click()
    {
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            PlayerPrefs.SetInt("sound_on", 0);
        }
        else
        {
            PlayerPrefs.SetInt("sound_on", 1);
        }
        Refresh();
    }
}
