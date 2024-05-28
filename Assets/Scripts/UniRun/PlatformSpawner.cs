using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniRun
{
    public class PlatformSpawner : MonoBehaviour
    {
        public GameObject platformPrefab;
        public int count = 3;

        public float spawnTimeMin = 1.25f;
        public float spawnTimeMax = 2.25f;
        private float spawnTime;

        public float yMin = -3.5f;
        public float yMax = -1.5f;
        private float yPos;
        private float xPos = 20f;

        private GameObject[] platforms;
        private int currentIdx = 0;
        private Vector2 poolPosition = new Vector2(0, -25);
        private float lastSpawnTime;

        private void Start()
        {
            platforms = new GameObject[count];
            for(int i = 0; i < platforms.Length; i++)
            {
                platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
            }

            lastSpawnTime = 0f;
            spawnTime = 0f;
        }

        private void Update()
        {
            if(GameManager.instance.isGameOver || !GameManager.instance.isGameStart)
            {
                return;
            }
            
            if(GameManager.instance.isGameStart)
            {
                if (Time.time >= lastSpawnTime + spawnTime)
                {
                    lastSpawnTime = Time.time;  //Time.time == 게임이 시작된 경과시간
                    spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);

                    yPos = Random.Range(yMin, yMax);
                    platforms[currentIdx].SetActive(false);  // OnEnable() 활성화 해주기 위해
                    platforms[currentIdx].SetActive(true);

                    platforms[currentIdx].transform.position = new Vector2(xPos, yPos);

                    currentIdx++;

                    if (currentIdx >= platforms.Length)
                    {
                        currentIdx = 0;
                    }
                }
            }
        }
    }
}

