using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text scoreTextPrefab;
    public GameObject coin;
	private int points = 0;
	void Update()
	{
		scoreTextPrefab.text = "Score: " + points;
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            coin.SetActive(false);
            points++;
            Debug.Log("kolizja");

        }
    }
}
