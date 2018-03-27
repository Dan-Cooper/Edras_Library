// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFeet : MonoBehaviour {

	void OnCollisionEnter(Collision coll){
		Debug.Log("1a");
		if (coll.gameObject.tag == "Moving Platform") {
			transform.parent = coll.transform;
			Debug.Log("1b");
		}
	}
	void OnCollisionExit(Collision coll){
		Debug.Log("2a");
		if (coll.gameObject.tag == "Moving Platform") {
			transform.parent = null;
			Debug.Log("2b");
		}
	}
}
