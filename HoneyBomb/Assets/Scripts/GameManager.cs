using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // GAME OBJECTS
    GameObject player;
    Camera cam;
    public GameObject beePrefab;
    public Transform beeSpawnPoint;
    public float beginSpawnTime = 1f;

    // GAME VARIABLES
    public int honeyMaxAmt = 200;
    public int currentHoneyAmt = 0;
    public int cannonHoneyAmt = 0;
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

        //InvokeRepeating("beeSpawn", beginSpawnTime, 15f);
	}

    public void beeSpawn ()
    {
        Instantiate(beePrefab, beeSpawnPoint.position, new Quaternion(0f, 0f, 0f, 0f));

    }

    public bool tooMuchHoney ()
    {
        return currentHoneyAmt < honeyMaxAmt;
    }
}
