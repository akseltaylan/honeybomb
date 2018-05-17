using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoneyCollecting : MonoBehaviour {

    GameObject player;
    Camera cam;
    public GameObject beePrefab;
    public static int fullHoneyAmt = 50;
    public int currentHoneyAmt;
    public Image honeyBarFill;

    public static int distanceThreshold = 25;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = FindObjectOfType<Camera>();
        currentHoneyAmt = fullHoneyAmt;
    }
	
	void Update () {
        if (honeyAttainable())
        {
            honeyBarFill.enabled = true;
            Debug.Log("You can gather this honey!");

            // actual gathering of the honey
            if (Input.GetButton("Space") && currentHoneyAmt > 0)
            {
                StartCoroutine(gatherHoney());
            }

            if (currentHoneyAmt == 0)
            {
                Instantiate(beePrefab, transform.position, new Quaternion(0f,0f,0f,0f));
                Destroy(honeyBarFill);
                Destroy(gameObject);
            }
        }
        else
        {
            honeyBarFill.enabled = false;
        }
	}

    // checks if honey is in camera's view and player is close enough to gather it
    public bool honeyAttainable()
    {

        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        bool closeEnough = Mathf.Abs(transform.position.x - player.transform.position.x) < distanceThreshold && Mathf.Abs(transform.position.z - player.transform.position.z) < distanceThreshold;
        bool maxHoney = GameManager.instance.tooMuchHoney();

        return onScreen && closeEnough && maxHoney;
    }

    // function to gather honey
    IEnumerator gatherHoney()
    {
        currentHoneyAmt -= 1;
        GameManager.instance.currentHoneyAmt += 1;
        UIManager.instance.currentHoneyBar.fillAmount = GameManager.instance.currentHoneyAmt / 200f;
        honeyBarFill.fillAmount = currentHoneyAmt / 50f;
        yield return new WaitForEndOfFrame();
    }
}
