using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToggleEndMenu()
    {
        int points = PlayerPrefs.GetInt("points", 0);
        gameObject.SetActive(true);
        scoreText.text = points.ToString();
    }
}
