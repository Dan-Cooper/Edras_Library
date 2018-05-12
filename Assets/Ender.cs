using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ender : MonoBehaviour {
	public GameObject BlackScreen;

	void Start () {
		
	}

	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GetComponent<Animator> ().SetTrigger ("Player");
			StartCoroutine (Fade ());
			other.GetComponent<PlayerControler> ().enabled = (false);
		}
	}
	public IEnumerator Fade(){
		yield return new WaitForSeconds(0.5f);
		BlackScreen.SetActive (true);

	}
}