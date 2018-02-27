using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDespawn : MonoBehaviour {


	void OnTriggerExit(Collider other)
	{
		Debug.Log("Exited");
		Destroy(this.gameObject);
	}

}
