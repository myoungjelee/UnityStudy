using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgePlayer : MonoBehaviour
{
    private Rigidbody playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트 (물리)
    public float speed = 8; // 이동속도

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // GetKey는 누르고있는동안 계속 체크
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //{
        //    playerRigidbody.AddForce(0f, 0f, speed);
        //}
        //if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //{
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}
        //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //{
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //{
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}

        // 수평, 수직축의 입력을 감지하여 저장하는 방법
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = speed * xInput;
        float zSpeed = speed * zInput;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;

        // GetKeyDown 은 키를 눌렀을 때 한번만 체크
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    Die();
        //}

        //if (Input.GetButtonDown("MJJump"))
        //{
        //    playerRigidbody.AddForce(0f, 1000f, 0f);
        //}
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.GameOver();
    }
}
