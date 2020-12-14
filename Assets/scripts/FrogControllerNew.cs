using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogControllerNew : MonoBehaviour
{
    public float gravity = 100.0f;
    public int points = 0;
    public int currentpoints = 0;
    public Material[] skins;
    public SkinnedMeshRenderer mesh;
    public Text scoreText;
    public DeathMenu deathMenu;
    private CharacterController cc;
    private Animator anim;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        int skin = PlayerPrefs.GetInt("skin", 0);
        SetSkin(skin);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            anim.SetTrigger("Jump");
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0.0f, -2.0f, 0.0f));
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f));
        }

        if(cc.isGrounded)
        {
            moveDirection.y = -cc.stepOffset / Time.deltaTime;
        }
        else 
        {
            moveDirection.y -= gravity * Time.deltaTime;
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
       
    }

    public void SetSkin(int skin)
    {
        mesh.material = skins[skin];
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "death")
        {
            deathMenu.ToggleEndMenu();
        }
    }
}
