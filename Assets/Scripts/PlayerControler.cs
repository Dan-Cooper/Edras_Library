using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerControler : MonoBehaviour
{
	private CharacterController charControl;
	public float walkSpeed;

	// Use this for initialization
	void Awake()
	{
		charControl = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer();
	}

	void MovePlayer()
	{
		//Gets Raw input data
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		//Modifies data for speed and direction
		Vector3 moveSide = transform.right * h * walkSpeed;
		Vector3 moveForw = transform.forward * v * walkSpeed;
		//Makes change to object
		charControl.SimpleMove(moveSide);
		charControl.SimpleMove(moveForw);

	}
}
