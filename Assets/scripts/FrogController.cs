using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogController : MonoBehaviour
{
    public static FrogController instance;
    public Text scoreTextPrefab;
    public int points = 0;
    public DeathMenu deathMenu;

    public float jumpSpeed = 100.0F;
    public float gravity = 100.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public float moveSpeed = 1f;
    public float moveSpeedJumping = 1f;
    private Animator animator;
    private bool frogIsMoving = false;
    public PauseMenu pauseMenu;

    public Material[] skins;
    public SkinnedMeshRenderer mesh;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        frogIsMoving = true;

        int skin = PlayerPrefs.GetInt("skin", 0);
        SetSkin(skin);
        setPoints(0);
    }

    public void stopFrogMovement()
    {
        frogIsMoving = false;
    }

    public void startFrogMovement()
    {
        frogIsMoving = true;
        transform.localEulerAngles = Vector3.zero;
    }

    public void setPoints(int newScore)
    {
        points = newScore;
        PlayerPrefs.SetInt("points", points);
    }

    void Update()
    {
        if (frogIsMoving)
        {
            if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;

            moveDirection.x = 0;
            moveDirection.z = 0;

            animator.SetBool("jumping", controller.isGrounded == false);
            if (controller.isGrounded)
            {
                moveDirection += transform.forward * moveSpeed;
            }
            else
            {
                moveDirection += transform.forward * moveSpeedJumping;
            }
            moveDirection += transform.forward * moveSpeed;
            animator.SetBool("walking", true);

            if (Input.GetKey(KeyCode.LeftArrow) && controller.isGrounded)
            {
                transform.Rotate(new Vector3(0, -2, 0));
            }

            if (Input.GetKey(KeyCode.RightArrow) && controller.isGrounded)
            {
                transform.Rotate(new Vector3(0, 2, 0));
            }

            controller.Move(moveDirection * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                frogIsMoving = false;
                pauseMenu.TogglePauseMenu();
            }
        }
        scoreTextPrefab.text = "Score: " + points.ToString();
    }

    public void SetSkin(int skin)
    {
        mesh.material = skins[skin];
    }
}

