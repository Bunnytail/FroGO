using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
