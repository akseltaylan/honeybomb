using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // GAME OBJECTS
    GameObject player;
    Camera cam;

    // GAME VARIABLES
    public int honeyMaxAmt = 25;
    public int honeyNeeded = 100;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = FindObjectOfType<Camera>();
	}
}
