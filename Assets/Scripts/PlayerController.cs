using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioSource jumpSound;
    public GameObject uiManagerControl;
    public Rigidbody2D playerRb;
    public float speed;
    public float jumpForce;
    public float horizontalInput;
    public float verticalInput;
    bool isGround = true;
    bool lookRight = true;
    Vector3 playerScale;
    Animator playerAnimatior;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimatior = GetComponent<Animator>();
        jumpSound = GetComponent<AudioSource>();
        
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector3(horizontalInput * speed * Time.deltaTime, playerRb.velocity.y, 0);

        if(horizontalInput > 0 && lookRight==false)
        {
            playerTranslate();
        }
        if(horizontalInput < 0 && lookRight==true)
        {
            playerTranslate();
        }
        
        playerAnimatior.SetFloat("Speed", Mathf.Abs(horizontalInput));

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            jumpSound.Play();
            playerRb.AddForce(new Vector2(0, jumpForce));
            isGround = false;
            playerAnimatior.SetBool("Jump", true);
        }
        //if (Mathf.Approximately(playerRb.velocity.y, 0) && playerAnimatior.GetBool("Jump"))
        if(isGround == true && playerAnimatior.GetBool("Jump"))
        {
            playerAnimatior.SetBool("Jump", false);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if(collision.gameObject.tag == "Obstacles")
        {      
            Time.timeScale = 0;
            uiManagerControl.SetActive(true);
        }

    }

    

    void playerTranslate()
    {
        lookRight = !lookRight;
        playerScale = gameObject.transform.localScale;
        playerScale.x = playerScale.x * -1;
        gameObject.transform.localScale =playerScale;
    }
    


}
