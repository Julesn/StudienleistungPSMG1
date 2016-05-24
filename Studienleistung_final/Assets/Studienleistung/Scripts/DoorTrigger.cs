using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour {

	bool inZone;
	Door door;
	UIHandler uih;
	Text PressEnter;

	void Update(){
		if (inZone == true) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				Debug.Log (door);
				if (door.doorStatus == false) {
					door.doorStatus = true;
				} else {
					door.doorStatus = false;
				}
			}
		}
	}

	void Start(){
		door = transform.parent.parent.GetComponentInChildren<Door>();
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("TriggerEnter");
		inZone = true;
		PressEnter.text = "Press Enter";
	}

	void OnTriggerExit(Collider other){
		Debug.Log ("TriggerExit");
		inZone = false;
		PressEnter.text = "";
	}

}