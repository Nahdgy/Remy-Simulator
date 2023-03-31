using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
  
    public float countStart, currentTime;
    [SerializeField]
    private Text timer;
    [SerializeField]
    private GameObject remy;
    [SerializeField]
    private Button _button;
    RemyController player;


  
    private void Start()
    {
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
    }

    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        timer = GameObject.FindObjectOfType<Text>();
        currentTime = countStart;
        player = GameObject.FindObjectOfType<RemyController>();
    }

    private void Update()
    {
        
        if(player != null)
        {
            CallTimer();
        }
        else
        {
            player = GameObject.FindObjectOfType<RemyController>();
          
        }
       
    }

    void CallTimer()
    {
        if (timer != null)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                currentTime = 0;
            }
            Timmer(currentTime);
        }
    }



    public void WinScene()
    {
        SceneManager.LoadScene("Win");
    }

    private void GameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void Timmer(float timeTodisplay)
    {
        if(timeTodisplay < 0) 
        {
            timeTodisplay = 0;
        }
        string minutes = Mathf.FloorToInt(timeTodisplay / 60).ToString();
        string seconds = Mathf.FloorToInt(timeTodisplay % 60).ToString("f0");

        timer.text = minutes + ":" + seconds;

        if(currentTime == 0)
        {
            GameOverScene();
        }
    }
}
