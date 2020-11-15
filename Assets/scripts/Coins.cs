using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    //public Text scoreTextPrefab;
    //public GameObject coin;
	//private int points = 0;
	void Update()
	{
        transform.Rotate(Vector3.up);
	//	scoreTextPrefab.text = "Score: " + points;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Frog")
        {
            int points = PlayerPrefs.GetInt("points", 0);
            FrogController.instance.setPoints(++points);
            
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            //coin.SetActive(false);
            //points++;
            //Debug.Log("kolizja");
            StartCoroutine(WaitingToResetCoins());
        }
    }

    IEnumerator WaitingToResetCoins()
    {
        yield return new WaitForSeconds(15);
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
