using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	bool trappedIn;
	float bombPosActive = 1.5f;
	float bombPosInactive = 3f;
	float yPos;

	public bool bombStatus {
		get {
			return trappedIn;
		}
		set { 
			trappedIn = value;
		}
	}

	void Update(){
		yPos = transform.position.y;
		if (trappedIn == true) {
			if (yPos > bombPosActive) {
				Vector3 open = new Vector3 (0, -bombPosActive, 0);
				transform.Translate (open * Time.deltaTime, Space.World);
			}
		}
		if (trappedIn == false) {
			if (yPos < bombPosInactive) {
				Vector3 close = new Vector3 (0, bombPosInactive, 0);
				transform.Translate (close * Time.deltaTime, Space.World);
			}
		}
	}
}
