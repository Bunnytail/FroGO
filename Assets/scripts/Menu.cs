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
        buttonSound.Play();
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void OpenShop()
    {
        buttonSound.Play();
        shop.SetActive(true);
    }

}
