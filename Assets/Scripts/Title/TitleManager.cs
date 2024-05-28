using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    //// TextMeshPro를 사용 할 때에는 Text 클래스 사용안함.
    ////public Text title;
    //public TextMeshProUGUI titleText;
    //public TextMeshProUGUI noticeText;

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Return))
    //    {
    //        StartGame();
    //    }
    //}
    //public void StartGame()
    //{
    //    SceneManager.LoadScene("Dodge");


    //}
    public void OpenDodgeScene()
    {
        SceneManager.LoadScene("Dodge");
    }

    public void OpenUniRunScene()
    {
        SceneManager.LoadScene("UniRun");
    }
}
