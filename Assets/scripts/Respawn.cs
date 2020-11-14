using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public DeathMenu deathMenu;
    public FrogController frog;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deathMenu.ToggleEndMenu();

            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
            player.transform.rotation = respawnPoint.transform.rotation;

            frog.stopFrogMovement();
        }
    }
}
