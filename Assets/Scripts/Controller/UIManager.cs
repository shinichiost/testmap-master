using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject winbanner, losebanner, pausebanner;
    public static UIManager instance;
    public GameObject panel;
    public AudioSource soundtrack;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
  
    public void showwinbanner(bool win)
    {

        PauseGame();
        winbanner.SetActive(win);
        panel.SetActive(true);
    }
    public void showlosebanner(bool lose)
    {
        PauseGame();
        losebanner.SetActive(lose);
        panel.SetActive(true);
    }
    public void showpausebanner(bool pause)
    {
        if (pause)
            PauseGame();
        else ResumeGame();
        pausebanner.SetActive(pause);
        panel.SetActive(pause);
    }
    public void PauseGame()
    {
        soundtrack.Pause();
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        soundtrack.UnPause();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
