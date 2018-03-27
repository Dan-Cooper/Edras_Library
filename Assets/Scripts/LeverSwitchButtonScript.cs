// Cathy made this. Finished for now.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitchButtonScript : MonoBehaviour {
	[Header("Make this 'trigger' gameobject a ")]
	[Header("      child of the switch/lever object.")]

	[Header("The box collider is the area the ")]
	[Header("      player is allowed to interact ")]
	[Header("      with the object.")]

	[Header("Right Click to change a true/false ")]
	[Header("      variable.")]

	[Header("Contact Cathy, so I can add a more ")]
	[Header("      specific script.")]
	[Space]

	public bool singleUse;
	public bool playerInputRequired;
	[Space]

	[Header("Intial state: ")]
	public bool isOn;
	public bool isEnabled;

	private Transform playerLocation;

	void Start() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		playerLocation = GetComponent<Transform>();
	}

	void OnTriggerStay (Collider other) {		// when the player is close by
		if(playerInputRequired){
			if(isEnabled && Input.GetButtonDown("Switch Plat")){
				isOn = !isOn;
				Debug.Log("isOn = " + isOn);
				if(singleUse){
					isEnabled = false;
					Debug.Log("isEnabled = " + isEnabled);
				}
			}
			// check if player is facing switch

		}
	}

	void OnTriggerEnter(Collider other) {
		if(isEnabled && !playerInputRequired){
			isOn = !isOn;
			Debug.Log("isOn = " + isOn);
			if(singleUse){
				isEnabled = false;
				Debug.Log("isEnabled = " + isEnabled);

			}
		}
	}
}
