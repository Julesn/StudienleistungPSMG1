using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	bool isOpen;
	float doorPosOpen = 1.5f;
	float doorPosClosed = 3f;
	float yPos;

	public bool doorStatus {
		get {
			return isOpen;
		}
		set { 
			isOpen = value;
		}
	}

	void Update(){
		yPos = transform.position.y;
		if (isOpen == true) {
			if (yPos > doorPosOpen) {
				Vector3 open = new Vector3 (0, -doorPosOpen, 0);
				transform.Translate (open * Time.deltaTime, Space.World);
			}
		}
		if (isOpen == false) {
			if (yPos < doorPosClosed) {
				Vector3 close = new Vector3 (0, doorPosClosed, 0);
				transform.Translate (close * Time.deltaTime, Space.World);
			}
		}
	}
		
}
