using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject shop;
    public AudioSource buttonSound;
    public void StartGame()
    {
        SceneManager.LoadScene("game");
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            buttonSound.Play();
        }
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void OpenShop()
    {
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            buttonSound.Play();
        }
        shop.SetActive(true);
    }

}
