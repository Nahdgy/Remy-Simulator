using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField]
    private UI ui;
    [SerializeField]
    private float easy, normal, difficult;

    private void Awake()
    {
        ui = GameObject.FindObjectOfType<UI>();
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Difficulty");
    }
    public void RetourButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void EasyButton()
    {
        ui.countStart = easy;
        SceneManager.LoadScene("Nahdgy_Scene");
    }
    public void NormalButton()
    {
        ui.countStart = normal;
        SceneManager.LoadScene("Nahdgy_Scene");
    }
    public void DifficultButton()
    {
        ui.countStart = difficult;
        SceneManager.LoadScene("Nahdgy_Scene");

    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credit");
    }
}
