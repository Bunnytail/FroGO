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
    //public Sprite[] textures = new Sprite[3];
    public List<Sprite> textures = new List<Sprite>();
    void Start()
    {
        slide = 0;
        image.sprite = textures[slide];
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
        if (slide >= textures.Count)
        {
            SceneManager.LoadScene("menu");
        }
        else
        {
            image.sprite = textures[slide];
            //image.GetComponent<Image>().sprite = textures[slide];
        }
    }

    public void Skip()
    {
        SceneManager.LoadScene("menu");
    }
}
