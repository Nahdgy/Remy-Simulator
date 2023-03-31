using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject baseUI, difficultyUI;
    [SerializeField]
    private UI ui;
    [SerializeField]
    private float easy, normal, difficult;

    public void PlayButton()
    {
        baseUI.SetActive(false);
        difficultyUI.SetActive(true);

    }
    public void RetourButton()
    {
        baseUI.SetActive(true);
        difficultyUI.SetActive(false);
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
}
