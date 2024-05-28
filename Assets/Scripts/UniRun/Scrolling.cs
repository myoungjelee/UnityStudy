using Dodge;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UniRun
{
    public class Scrolling : MonoBehaviour
    {
        public float speed = 10f;

        private void Start()
        {
            enabled = false;
        }
        void Update()
        {
            if (GameManager.instance.isGameOver) return;

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}

