using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartWinSceneManager : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
