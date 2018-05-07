// Cathy made this. Finished for now.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLeverScript : MonoBehaviour {
	[Header("-> Attach this script to lever object.")]
	[Header("-> Make door object a child of")]
	[Header("     lever object.")]
	[Header("-> In the box collider component,")]
	[Header("     check 'Is Trigger' box")]
	[Header("-> The box collider is the area the ")]
	[Header("     player is allowed to interact ")]
	[Header("     with the object.")]
	[Header("-> Right Click to interact")]
	[Header("        when in trigger box.")]

	[Space]

	public bool singleUse = true;
	public bool requiresPlayerInput = true;
	[Header("Put door object here: ")]
	public GameObject door;

	private bool isOpen;
	private bool canOpen;

	void Start() {
		isOpen = false;
		canOpen = true;
	}

	void OnTriggerStay (Collider other) {		// when the player is close by
		if(other.tag == "Player") {
			if(requiresPlayerInput){
				if(canOpen && Input.GetButtonDown("Switch Plat")){
					isOpen = !isOpen;
					OpenDoor();
													// Ctrl + F add sound here
					Debug.Log("isOpen = " + isOpen);
					if(singleUse){
						canOpen = false;
						OpenDoor();
						Debug.Log("canOpen = " + canOpen);
					}
				}
				// check if player is facing lever?

			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			if(canOpen && !requiresPlayerInput){
				isOpen = !isOpen;
				OpenDoor();
				Debug.Log("isOpen = " + isOpen);
				if(singleUse){
					canOpen = false;
					OpenDoor();
					Debug.Log("canOpen = " + canOpen);
				}
			}



		}
	}

	void OpenDoor(){
		if(isOpen){
			// Destorys all children
			Destroy(door);
		}
	}


}
