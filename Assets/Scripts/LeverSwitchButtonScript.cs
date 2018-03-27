// Cathy made this. Unfinished

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitchButtonScript : MonoBehaviour {
	public bool singleUse;
	public bool playerInputRequired;

	[HideInInspector] public bool isOn;
	[HideInInspector] public bool isEnabled;

//	public Vector3 playerLocation;

//	void Start() {
//		GameObject player = GameObject.FindGameObjectsWithTag("Player");
//		playerLocation = GetComponent<Transform>();
//	}

	void OnTriggerStay (Collider other) {		// when the player is close by
		if(playerInputRequired){
			if(isEnabled && Input.GetButtonDown("Submit")){
				isOn = true;
				if(singleUse){
					enabled = false;
				}
			}
			// check if player is facing switch

		}
	}

	void OnTriggerEnter(Collider other) {
		if(isEnabled && !playerInputRequired){
			isOn = true;
			if(singleUse){
				enabled = false;
			}
		}
	}
}
