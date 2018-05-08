using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Compilation;
using UnityEngine;

public class LedgeDespawn : MonoBehaviour {


	void OnTriggerExit(Collider other)
	{
		GameObject.Find("Player").GetComponent<PlayerControler>().LedgeSpawned = false;
		Debug.Log("Exited");
		Destroy(this.gameObject);
	}

}
