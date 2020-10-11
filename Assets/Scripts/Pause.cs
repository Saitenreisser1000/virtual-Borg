using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour {

    bool paused;
    GameObject player;
    GameObject menu;
    Component pauseMenu;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        menu = GameObject.Find("Menu");
        PauseMenu(false);

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (!paused)
            {
                //player.GetComponent<FirstPersonController>().enabled = false;
                PauseMenu(true);
                paused = true;               
                Time.timeScale = 0;         
            }
            else
            {
                //player.GetComponent<FirstPersonController>().enabled = true;
                PauseMenu(false);
                paused = false;
                Time.timeScale = 1;
            }
        }
	}

    void PauseMenu(bool active)
    {
        if (active)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }

    }
}
