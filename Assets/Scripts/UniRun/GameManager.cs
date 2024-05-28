using DG.Tweening;
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
        public bool isGameStart;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI bestScoreText;
        public TextMeshProUGUI gameoverText;
        public TextMeshProUGUI startText;
        public Image[] lifes;
        private int lifeCount = 5;

        private int score = 0;
        private int bestScore = 0;
        

       private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                //DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning("두개 이상의 매니저가 존재합니다.");
                Destroy(gameObject);
            }

            //lifes = new Image[lifeCount];

        }

        private void Start()
        {
            ResetGame();
            startText.DOText("준비..", 1f);
            bestScoreText.text = $"Best Score : {PlayerPrefs.GetInt("UniRunBestScore")}";
        }

        private void Update()
        {
            if (isGameOver && Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("TitleScene");
            }
        }

        public void AddScore(int newScore)
        {
            if (!isGameOver)
            {
                score += newScore;
                scoreText.text = $"Score: {score}";

                bestScore = PlayerPrefs.GetInt("UniRunBestScore");
                if (score > bestScore)
                {
                    PlayerPrefs.SetInt("UniRunBestScore", score);
                    scoreText.text = $"<rainb>Score: {score}";
                }
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
        public void ResetGame()
        {
            StartCoroutine(StartGame());  
        }

        IEnumerator StartGame()
        {
            gameoverText.gameObject.SetActive(false);
            //player.transform.position = new Vector3(0, 1, 0);
            //player.SetActive(true);
            yield return new WaitForSeconds(2);
            startText.text = "";
            startText.DOText("시작!!", 1f);
            yield return new WaitForSeconds(1);
            startText.gameObject.SetActive(false);
            //gameStart = true;
            Scrolling[] scrollings = FindObjectsOfType<Scrolling>();
            foreach (Scrolling scrolling in scrollings)
            {
                scrolling.enabled = true;
            }
            isGameStart = true;
        }
    }
}

