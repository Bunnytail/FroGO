using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void TogglePauseMenu()
    {
        gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("menu");
    }
}
