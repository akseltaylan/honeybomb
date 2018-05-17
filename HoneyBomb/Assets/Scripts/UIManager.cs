using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Image currentHoneyBar;
    public Image warningIcon;
    public Image thermometer;

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

    public void replayOnClick()
    {
        Camera cam = FindObjectOfType<Camera>();
        Destroy(cam);
        SceneManager.LoadScene("AkselWorking2");
    }
}
