using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {
	private Rigidbody rb;
	public Rigidbody rbEnd;	// EndPlatform will move with parent gameobject after Start function

	public float speed;
	private Vector3 start;
	private Vector3 end;
	private Vector3 moveVector;
	private bool goingBack;

	void Start () {
		rb = GetComponent<Rigidbody>();

		start = rb.position;
		end = rbEnd.position;	// only EndPlatform's initial position is stored.
		moveVector = end - start;

		goingBack = false;
	}

	void FixedUpdate () {
		if(!goingBack) {
			rb.velocity = moveVector.normalized * speed;
			if (rb.position == end) {				// only works if no decimals
				goingBack = true;
			}
		}
		else if(goingBack) {
			rb.velocity = -moveVector.normalized * speed;
			if(rb.position == start) {
				goingBack = false;
			}
		}
	}
}
