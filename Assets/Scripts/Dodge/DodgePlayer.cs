using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgePlayer : MonoBehaviour
{
    private Rigidbody playerRigidbody; // �̵��� ����� ������ٵ� ������Ʈ (����)
    public float speed = 8; // �̵��ӵ�

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // GetKey�� �������ִµ��� ��� üũ
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

        // ����, �������� �Է��� �����Ͽ� �����ϴ� ���
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = speed * xInput;
        float zSpeed = speed * zInput;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;

        // GetKeyDown �� Ű�� ������ �� �ѹ��� üũ
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
