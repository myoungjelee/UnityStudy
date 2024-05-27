using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public GameObject gameoverText;
    //public Text timeText; 
    //public Text recordText;

    //private float surviveTime;
    //private bool isGameover;

    //void Start()
    //{
    //    surviveTime = 0f;
    //    isGameover = false;
    //}


    //void Update()
    //{
    //    if(!isGameover)
    //    {
    //        surviveTime += Time.deltaTime;
    //        timeText.text = $"Time : {(int)surviveTime}";
    //    }
    //    else
    //    {
    //        if(Input.GetKeyDown(KeyCode.R))
    //        {
    //            SceneManager.LoadScene("TitleScene");
    //        }
    //    }
    //}

    //public void EndGame()
    //{
    //    isGameover = true;
    //    gameoverText.SetActive(true);

    //    float bestTime = PlayerPrefs.GetInt("Best Record");

    //    if(surviveTime > bestTime)
    //    {
    //        bestTime = surviveTime;
    //        PlayerPrefs.SetInt("Best Record", (int)surviveTime);
    //    }
    //        recordText.text = $"Best Record : {(int)bestTime}";
    //}

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI startText;
    public GameObject player;

    private float score;
    public bool gameStart= false;

    private void Start()
    {
        ResetGame();
        startText.DOText("�غ�..", 1f);
        //startText.text = "�غ�..";
        bestScoreText.text = $"<rainb>�ְ� ���� : {PlayerPrefs.GetFloat("BestScore").ToString("F3")}"; 
    }

    private void Update()
    {
        if (gameStart)
        {
            score += Time.deltaTime;
            scoreText.text = $"���� ���� : {score.ToString("F3")}";
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }

    public void GameOver()
    {
        gameStart = false;
        Bullet[] bullets = FindObjectsOfType<Bullet>();
        foreach  (Bullet bullet in bullets)
        {
            Destroy(bullet);
            //Destroy(bullet.gameObject);
        }
        gameOverText.gameObject.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestScore");

        if( score > bestScore)
        {
            PlayerPrefs.SetFloat("BestScore", score);
        }
        bestScoreText.text = $"<rainb>�ְ� ���� : {bestScore.ToString("F3")}";
    }

    public void ResetGame()
    {
        StartCoroutine(StartGame());  //���ϴ� �Լ�?? �긦 ����ϴ� ����??
    }

    IEnumerator StartGame()
    {
        gameOverText.gameObject.SetActive(false);
        player.transform.position = new Vector3(0,1,0);
        player.SetActive(true);
        yield return new WaitForSeconds(2);  
        startText.text = "";
        startText.DOText("����!!", 1f);
        yield return new WaitForSeconds(1);
        startText.gameObject.SetActive(false);
        gameStart = true;
    }
}
