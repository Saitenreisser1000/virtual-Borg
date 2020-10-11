using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossingCollider : MonoBehaviour {

    Collider col;
    public string movedInFrom;
    public float inTime;
    public string movedOutFrom;
    public float outTime;
    public bool playerIsIn;
    public List<GameObject> neighbours;
    public GameObject management;


	// Use this for initialization
	void Start () {
        col = GetComponent<Collider>();
        management = GameObject.Find("_Management");
        col.isTrigger = true;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (other.transform.position.x > transform.position.x + transform.localScale.x / 2)
            {
                movedInFrom = "west";
            }
            if (other.transform.position.x < transform.position.x - transform.localScale.x / 2)
            {
                movedInFrom = "east";
            }
            if (other.transform.position.z > transform.position.z + transform.localScale.z / 2)
            {
                movedInFrom = "south";
            }
            if (other.transform.position.z < transform.position.z - transform.localScale.z / 2)
            {
                movedInFrom = "north";
            }
            inTime = Time.time;
            playerIsIn = true;
            management.GetComponent<CrossingManager>().TriggerCrossingCollider(gameObject, movedInFrom);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.transform.position.x > transform.position.x + transform.localScale.x / 2)
            {
                movedOutFrom = "west";
            }
            if (other.transform.position.x < transform.position.x - transform.localScale.x / 2)
            {
                movedOutFrom = "east";
            }
            if (other.transform.position.z > transform.position.z + transform.localScale.z / 2)
            {
                movedOutFrom = "south";
            }
            if (other.transform.position.z < transform.position.z - transform.localScale.z / 2)
            {
                movedOutFrom = "north";
            }
            outTime = Time.time;
            playerIsIn = false;

            //send to managementsystem which direction player moved out of collider
            management.GetComponent<CrossingManager>().LeaveCrossingCollider(gameObject, movedOutFrom);


        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
