using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimation : MonoBehaviour {

    public Animation anim;
    private bool moving;
    private bool left;
    private bool right;

	void Start () {
        left = true;
        right = false;
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)
        {
            moving = true;
        }
        else if (x == 0 && y == 0)
        {
            moving = false;
        }

        walking();
	}

    void walking()
    {
        if(moving)
        {
            if (left)
            {
                if (!anim.isPlaying)
                {
                    anim.Play("walkleft");
                    left = false;
                    right = true;
                }
            }
            if (right)
            {
                if (!anim.isPlaying)
                {
                    anim.Play("walkright");
                    left = true;
                    right = false;
                }
            }
        }
    }
}
