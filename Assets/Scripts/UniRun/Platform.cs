using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace UniRun
{
    public class Platform : MonoBehaviour
    {
        // const 상수는 항상 대문자로!!!
        private const int CREATE_RATIO = 30;
        public GameObject[] obstacles;
        public bool isStepped = false;

        private void OnEnable()
        {
            isStepped = false;

            foreach(var obstacle in obstacles)
            {
                //if (Random.Range(0, 3) == 0)  // 0,1,2
                //{
                //    obstacle.SetActive(true);
                //}
                //else
                //{
                //    obstacle.SetActive(false);
                //}
                if( Random.Range(0, 100) < CREATE_RATIO)
                {
                    obstacle.SetActive(true);
                }
                else
                {
                    obstacle.SetActive(false);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player" && !isStepped)
            {
                // Debug.Log($"{isStepped}");
                isStepped = true;
                GameManager.instance.AddScore(1);
            }
        }
    }
}


