using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class intro : MonoBehaviour

{
    public GameObject leftButton;
    public Image image;
    private int slide;
    public Sprite[] textures;
    void Start()
    {
        image.sprite = textures[slide];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Left()
    {
        if (slide > 0)
        {
            slide--;
            image.sprite = textures[slide];
        }
    }

    public void Right()
    {
        slide++;
        if (slide >= textures.Length)
        {
            SceneManager.LoadScene("menu");
        }
        else
        {
            image.sprite = textures[slide];
        }
    }

    public void Skip()
    {
        SceneManager.LoadScene("menu");
    }
}
