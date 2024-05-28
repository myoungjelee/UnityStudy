using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UniRun
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public bool isGameOver;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI gameoverText;
        //public TextMeshProUGUI lifeText;
        public Image[] lifes;
        private int lifeCount = 5;

        private int score = 0;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                // DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning("두개 이상의 매니저가 존재합니다.");
                Destroy(gameObject);
            }

            //lifes = new Image[lifeCount];

        }

        private void Update()
        {
            if (isGameOver && Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        public void AddScore(int newScore)
        {
            if (!isGameOver)
            {
                score += newScore;
                scoreText.text = $"Score: {score}";
            }
        }

        public void OnPlayerDead()
        {
            isGameOver = true;
            gameoverText.gameObject.SetActive(true);
        }

        public int GetLifeCount()
        {
            return lifeCount;
        }

        public void RefreshLifeCount(int lifeCount)
        {
            //for (int i = 0; i < lifes.Length; i++)
            //{
            //    if (i < lifeCount)
            //    {
            //        lifes[i].gameObject.SetActive(true);
            //    }
            //    else
            //    {
            //        lifes[i].gameObject.SetActive(false);
            //    }
            //}
            //if (lifeCount < 5)
            //{
            //    lifes[lifeCount].gameObject.SetActive(false);
            //}

            for (int i = 0; i < lifes.Length; i++)
            {
                if (i >= lifeCount)
                {
                    lifes[i].gameObject.SetActive(false);
                }
            }
        }
    }
}

