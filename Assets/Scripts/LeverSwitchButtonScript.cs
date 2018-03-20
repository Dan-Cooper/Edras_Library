// Cathy made this. Unfinished

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitchButtonScript : MonoBehaviour {
	public bool isOn;
	public bool triggeredByPlayerInput;

	void OnTriggerStay (Collider other) {		// when the player is close by
		if(triggeredByPlayerInput){
			// check if player is facing switch

		}
	}

	void OnTriggerEnter(Collider other) {
		if(!triggeredByPlayerInput){
			isOn = !isOn;
		}
	}
}
