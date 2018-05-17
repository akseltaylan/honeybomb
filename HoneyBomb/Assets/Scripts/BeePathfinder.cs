using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeePathfinder : MonoBehaviour {

    public bool asleep;
    bool moving;
    public float bobbingAnimationSpeed = 1f;
    GameObject player;
    Camera cam;
    NavMeshAgent beeNavMesh;

    //gun
    int cooldown = 0;

    private void Update()
    {
        if (moving)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.time * bobbingAnimationSpeed), transform.position.z);
        }

        pathToPlayer();

        if(cooldown > 0)
        {
            cooldown--;
            if(cooldown == 0)
            {
                asleep = false;
                Debug.Log("BEE AWAKE");
            }
        }
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = FindObjectOfType<Camera>();
        beeNavMesh = GetComponent<NavMeshAgent>();
        asleep = false;
    }

    void pathToPlayer()
    {
        Ray findPlayer = cam.ScreenPointToRay(player.transform.position * -1f);
        RaycastHit hitPlayer;
        if (Physics.Raycast(findPlayer, out hitPlayer, Mathf.Infinity) && !asleep)
        {
            moving = true;
            beeNavMesh.destination = hitPlayer.point;
        }
        else
        {
            moving = false;
        }
    }

    //gun reaction
    private void OnTriggerEnter(Collider other)
    {
        if (cooldown == 0 && !asleep )
        {
            asleep = true;
            beeNavMesh.destination = transform.position;
            cooldown = 360;
            Debug.Log("BEE ASLEEP");
        }
    }
}
