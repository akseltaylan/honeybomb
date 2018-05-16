using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // GAME OBJECTS
    GameObject player;
    Camera cam;

    // GAME VARIABLES
    public int honeyMaxAmt = 200;
    public int currentHoneyAmt = 0;
    public int honeyNeeded = 1000;

    public static GameManager instance;

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

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = FindObjectOfType<Camera>();
	}

    public bool tooMuchHoney ()
    {
        return currentHoneyAmt < honeyMaxAmt;
    }
}
