using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniRun
{
    public class PlayerController : MonoBehaviour
    {
        public AudioClip deathAudio;
        public AudioClip jumpAudio;
        public float jumpForce = 700;

        private int jumpCount = 0;
        private bool isGrounded = false;
        private bool isDead = false;

        private Rigidbody2D playerRigidbody;
        //private CircleCollider2D playerCollider;
        private Animator animator;
        private AudioSource audioPlayer;

        private const int MAX_JUMP_COUNT = 2;

        private int currentLifeCount;
        private SpriteRenderer spriteRenderer;
        private bool isBlink = false;
        private Coroutine blinkCoroutine;

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            audioPlayer = GetComponent<AudioSource>();
            // playerCollider = GetComponent<CircleCollider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();    
            currentLifeCount = GameManager.instance.GetLifeCount();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpCount < MAX_JUMP_COUNT)
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

            GameManager.instance.OnPlayerDead();
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
                currentLifeCount = 0;
            }
            else if (collision.tag == "Obstacle" && !isDead)
            {
                //if (!isBlink)
                //{
                //    currentLifeCount--;

                //    isBlink = true;
                //    InvokeRepeating("Blinking", 0f, 0.5f);
                //    Invoke("StopBlinking", 5f);
                //}
                if (!isBlink)
                {
                    TaskDamage();
                }
            }
            
            GameManager.instance.RefreshLifeCount(currentLifeCount);

            if(currentLifeCount <= 0)
            {
                Die();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.contacts[0].normal.y > 0.7f)  //0.7은 45도를 의미함
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

        void Blinking()
        {
            float newAlpha = (spriteRenderer.color.a == 1.0f) ? 0.5f : 1.0f;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
        }

        void StopBlinking()
        {
            isBlink = false;
            CancelInvoke("Blinking");
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1.0f);
        }

        void TaskDamage()
        {
            if(blinkCoroutine != null)
            {
                StopCoroutine(blinkCoroutine);
            }

            blinkCoroutine = StartCoroutine(BlinkEffect());          
        }

        IEnumerator BlinkEffect()
        {
            currentLifeCount--;
            isBlink = true;
            float endTime = Time.time + 5f;

            while(Time.time < endTime)
            {
                spriteRenderer.color = new Color(1, 1, 1, 0.5f);
                yield return new WaitForSeconds(0.5f);

                spriteRenderer.color = new Color(1, 1, 1, 1);
                yield return new WaitForSeconds(0.5f);
            }

            spriteRenderer.color = new Color(1, 1, 1, 1);
            isBlink = false;
        }
    }
}
