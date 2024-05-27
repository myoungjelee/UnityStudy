using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniRunPlayer : MonoBehaviour
{    
    public AudioClip deathAudio;
    public AudioClip jumpAudio;
    public float jumpForce = 700;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigidbody;
    private CircleCollider2D playerCollider;
    private Animator animator;
    private AudioSource audioPlayer;

    private const int MAX_JUMP_COUNT = 2;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        playerCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(jumpCount < MAX_JUMP_COUNT)
            {
                Jump();
                jumpCount++;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space) && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        animator.SetBool("bGrounded", isGrounded);

        //float xValue = Input.GetAxis("Horizontal");
        //float xSpeed = xValue * 10;

        //playerRigidbody.velocity = new Vector2(xSpeed, playerRigidbody.velocity.y);
        //if(xValue == 0)
        //{
        //    transform.rotation = transform.rotation;
        //}
        //else if (xValue < 0) 
        //{
        //    transform.rotation = Quaternion.Euler(0, 180, 0);
        //}
        //else
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        audioPlayer.clip = deathAudio;
        audioPlayer.Play();

        playerRigidbody.velocity = Vector2.zero;
        isDead = true;

        UniRunManager.instance.OnPlayerDead(); 

    }

    private void Jump()
    {
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.AddForce(new Vector2(0, jumpForce));
        audioPlayer.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" && !isDead)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y> 0.7f)  //0.7은 45도를 의미함
        {
            isGrounded = true;
            jumpCount = 0;

            // 로그 찍어보는법
            //Debug.Log("착지");
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
