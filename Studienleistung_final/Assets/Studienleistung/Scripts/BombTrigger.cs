using UnityEngine;
using System.Collections;

public class BombTrigger : MonoBehaviour {

	bool inZone;
	Bomb bomb;

	void Update(){
		if (inZone == true) {
				if (bomb.bombStatus == false) {
					bomb.bombStatus = true;
				} else {
				bomb.bombStatus = false;
				}
		}
	}

	void Start(){
		bomb = transform.parent.parent.GetComponentInChildren<Bomb>();
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("TriggerEnter");
		inZone = true;
	}

	void OnTriggerExit(Collider other){
		Debug.Log ("TriggerExit");
		inZone = false;
	}
}
