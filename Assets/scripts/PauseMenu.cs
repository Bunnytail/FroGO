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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Return();
        }
    }

    public void TogglePauseMenu()
    {
        Time.timeScale = 0.0f;
        gameObject.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("menu");
    }
}
