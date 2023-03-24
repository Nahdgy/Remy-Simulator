using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void WinScene()
    {
        SceneManager.LoadScene("Win");
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
