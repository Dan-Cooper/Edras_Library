// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class KillVolumeScript : MonoBehaviour {

	[Header("For now, entering the KillVolume")]
	[Header("      will reset the current scene.")]

	[Space]
	public string dummyVariable;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			//	reload scene for now
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
			Debug.Log("Ya deid.");
		}

	}
}
