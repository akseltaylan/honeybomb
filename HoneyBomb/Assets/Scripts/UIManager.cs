using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Image currentHoneyBar;
    public GameObject warningIcon;
    public Image thermometer;
    public Text pauseMenuText;
    public GameObject gameOverUI;
    public GameObject cannonPrompt;

    // START SCREEN
    public GameObject startScreen;
    public GameObject aboutScreen;
    public GameObject controlsScreen;

    public static UIManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    public void gameOverState()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    public void gameOverReplayClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void backOnClick(GameObject curScreen)
    {
        curScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void playOnClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void aboutOnClick()
    {
        startScreen.SetActive(false);
        aboutScreen.SetActive(true);
    }

    public void controlsOnClick()
    {
        startScreen.SetActive(false);
        controlsScreen.SetActive(true);
    }

    public void quitOnClick()
    {
        Application.Quit();
    }

    public void replayOnClick()
    {
        SceneManager.LoadScene("Main");
    }
}
