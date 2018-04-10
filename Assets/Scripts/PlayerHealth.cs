// Cathy

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public Text m_health;
	private PlayerControler playCon;

	// Use this for initialization
	void Start () {
		GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
		playCon = playerObj.GetComponent<PlayerControler>();
		// m_health.text = "Health: " + playCon.
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
