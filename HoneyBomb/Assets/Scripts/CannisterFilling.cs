using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannisterFilling : MonoBehaviour {

    GameObject player;
    Camera cam;
    public int distanceThreshold = 25;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = FindObjectOfType<Camera>();
    }

	void Update () {
        if (closeToCannister())
        {
            Debug.Log("You're close enough to fill the cannon!");
            UIManager.instance.cannonPrompt.SetActive(true);
            if (Input.GetButton("Space"))
            { 
                StartCoroutine(fillCannon());
            }
        }
        else
        {
            UIManager.instance.cannonPrompt.SetActive(false);
        }
    }

    bool closeToCannister()
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);
        //bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        bool closeEnough = Mathf.Abs(transform.position.x - player.transform.position.x) < distanceThreshold && Mathf.Abs(transform.position.z - player.transform.position.z) < distanceThreshold;
        bool hasHoney = GameManager.instance.currentHoneyAmt != 0;

        return closeEnough && hasHoney;

    }

    IEnumerator fillCannon()
    {
            GameManager.instance.cannonHoneyAmt += 1;
            GameManager.instance.currentHoneyAmt -= 1;
            UIManager.instance.currentHoneyBar.fillAmount = GameManager.instance.currentHoneyAmt / 200f;
            UIManager.instance.thermometer.fillAmount = GameManager.instance.cannonHoneyAmt / 1000f;
            if (GameManager.instance.cannonHoneyAmt == GameManager.instance.honeyNeeded)
            {
                StartCoroutine(GameManager.instance.winGame());
            }
            // also add thermometer filling up here when it's in game
            yield return new WaitForEndOfFrame();
    }
}
