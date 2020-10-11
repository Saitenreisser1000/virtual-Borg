using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseRoom : MonoBehaviour {

    Dropdown chooseRoom;

	// Use this for initialization
	void Start () {
        chooseRoom = GetComponent<Dropdown>();
        chooseRoom.onValueChanged.AddListener(delegate {
            DropdownValueChanged();
        });
    }

    void DropdownValueChanged()
    {
        print("changed");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
