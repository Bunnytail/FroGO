using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject shop;
    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void OpenShop()
    {
        shop.SetActive(true);
    }

}
