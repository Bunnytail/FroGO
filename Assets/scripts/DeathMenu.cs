using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;
    public FrogControllerNew frog;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Return))
        {
            Restart();
        }
    }

    public void ToggleEndMenu()
    {
        int points = PlayerPrefs.GetInt("points", 0);
        gameObject.SetActive(true);
        scoreText.text = "" + frog.currentpoints;
    }

    public void Restart()
    {
        SceneManager.LoadScene("game");
    }
}
