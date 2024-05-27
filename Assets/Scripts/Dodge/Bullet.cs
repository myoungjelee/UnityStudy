using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dodge
{
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
                PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

                if (playerController != null)
                {
                    playerController.Die();
                }
            }
        }
    }
}


