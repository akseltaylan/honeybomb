using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyCollecting : MonoBehaviour {

    GameObject player;
    Camera cam;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(honeyAttainable());
	}

    // checks if honey is in camera's view and player is close enough to gather it
    public bool honeyAttainable()
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        bool closeEnough = Mathf.Abs(transform.position.x - player.transform.position.x) < 30 && Mathf.Abs(transform.position.z - player.transform.position.z) < 30;
        return onScreen && closeEnough;
    }
}
