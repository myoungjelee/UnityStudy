using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    public void OpenDodgeScene()
    {
        SceneManager.LoadScene("Dodge");
    }

    public void OpenUniRunScene()
    {
        SceneManager.LoadScene("UniRun");
    }
}
