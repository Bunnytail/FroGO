using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public Transform respawnPoint;
    public DeathMenu deathMenu;
    public FrogController frog;
    public static Respawn respawn;

    void Awake()
    {
        respawn = this;
    }

    void OnTriggerEnter(Collider other)
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
