using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    public float speed = 8.0f;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        speed = Random.Range(5f, 15f);
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 2.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DodgePlayer playerController = collision.gameObject.GetComponent<DodgePlayer>();

            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}

