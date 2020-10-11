using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLine : MonoBehaviour {

    LineRenderer lRenderer;
    GameObject player;
    GameObject targetPoint;
    GameObject targetPoint2;

    // Use this for initialization
    void Start() {
        /*lRenderer = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        targetPoint = GameObject.Find("crossing1");
        targetPoint2 = GameObject.Find("crossing2");
        lRenderer.SetPosition(1,new Vector3(targetPoint.transform.position.x, targetPoint.transform.position.y-1.8f, targetPoint.transform.position.z));

        lRenderer.SetPosition(2, new Vector3(targetPoint2.transform.position.x, targetPoint2.transform.position.y - 1.8f, targetPoint2.transform.position.z));*/
    }
	
	// Update is called once per frame
	void Update () {
        //lRenderer.SetPosition(0, player.transform.position);
	}
}
