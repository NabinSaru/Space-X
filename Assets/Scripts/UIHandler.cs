using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{
    [SerializeField] Text currentscoreTxt;
    [SerializeField] Text highscoreTxt;
    private void Start()
    {
        currentscoreTxt.text="Current Score:"+PlayerPrefs.GetInt("currentscore").ToString();
        if(PlayerPrefs.GetInt("currentscore")>PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore",PlayerPrefs.GetInt("currentscore"));
        }
        highscoreTxt.text="High Score:"+PlayerPrefs.GetInt("highscore").ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
