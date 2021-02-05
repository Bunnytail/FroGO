using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FrogControllerNew : MonoBehaviour
{
    public float gravity = 10.0f;
    public int points = 0;
    public int currentpoints = 0;
    public Material[] skins;
    public GameObject[] hats;
    public SkinnedMeshRenderer mesh;
    public Text scoreText;
    public PauseMenu pauseMenu;
    public DeathMenu deathMenu;
    private CharacterController cc;
    private Animator anim;
    private Vector3 moveDirection = Vector3.zero;
    public AudioSource jumpSound;
    public AudioSource coinSound;
    public AudioSource deathSound;
    private bool dead = false;
    private bool jump = false;


    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        int skin = PlayerPrefs.GetInt("skin", 0);
        SetSkin(skin);
        int hat = PlayerPrefs.GetInt("hat", 10);
        SetHat(hat);

        Time.timeScale = 1.0f;
    }

    void Update()
    {
        //Debug.Log(anim.speed);
        if(anim.speed < 2.2f)
        {
            anim.speed += Time.deltaTime * 0.01f;
        }

        if(pauseMenu.gameObject.activeSelf || deathMenu.gameObject.activeSelf)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if(jump && cc.isGrounded)
        {
            jump = false;
            anim.SetTrigger("Jump");
            if(PlayerPrefs.GetInt("sound_on", 1) == 1)
            {
                jumpSound.Play();
            }
        }

        bool jumping = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Armature|LONGJUMP NEW";

		float rotation = 120 * Time.deltaTime;
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0.0f, -rotation, 0.0f));
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0.0f, rotation, 0.0f));
        }

        if(cc.isGrounded)
        {
            moveDirection.y = -cc.stepOffset / Time.deltaTime;
        }
        else if (!jumping)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.TogglePauseMenu();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("game");
        }

        scoreText.text = "" + currentpoints;

    }

    void FixedUpdate()
    {
        cc.Move(moveDirection * Time.fixedDeltaTime);
    }

    public void AddPoint()
    {
        points = PlayerPrefs.GetInt("points", 0);
        points += 1;
        currentpoints += 1;
        PlayerPrefs.SetInt("points", points);
        if(PlayerPrefs.GetInt("sound_on", 1) == 1)
        {
            coinSound.Play();
        }
       
    }

    public void SetSkin(int skin)
    {
        mesh.material = skins[skin];
    }

    public void SetHat(int hat)
    {
        for (int i = 0; i < hats.Length; i++)
        {
            if(i == hat)
            {
                hats[i].gameObject.SetActive(true);
            }
            else
            {
                hats[i].gameObject.SetActive(false);
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "death" && !dead)
        {
            dead = true;
            deathMenu.ToggleEndMenu();
            if(PlayerPrefs.GetInt("sound_on", 1) == 1)
            {
                deathSound.Play();
            }
        }
    }
}
