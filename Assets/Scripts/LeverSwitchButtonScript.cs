using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitchButtonScript : MonoBehaviour {
	public GameObject Door;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Destroy (Door);
		}
	}
}
