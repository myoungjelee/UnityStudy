using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniRunManager : MonoBehaviour
{
    public static UniRunManager instance;

    public static bool isGameOver;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;

    private int score = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("두개 이상의 매니저가 존재합니다.");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        if(!isGameOver)
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
}
