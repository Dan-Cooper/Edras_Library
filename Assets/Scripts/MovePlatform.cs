﻿// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {
	public Rigidbody rbStart;
	public Rigidbody rbEnd;	// EndPlatform will move with parent gameobject after Start function

	public float speed;
	[Tooltip("wait time is in seconds")]
	public float waitTime;
	private float moveTime;

	[SerializeField]
	private bool goingBack;

	void Start () {
		moveTime = speed;
		goingBack = false;
		Debug.Log("moveTime = " + moveTime);

	}

	void FixedUpdate () {
		StartCoroutine(PlatformNowMove());
	}

	IEnumerator PlatformNowMove() {
        if (!goingBack) {
            transform.position = Vector3.MoveTowards(transform.position, rbEnd.position,
                speed * Time.deltaTime);
//			yield return new WaitUntil( () => rb.velocity == Vector3.zero);
			yield return new WaitForSecondsRealtime(moveTime + waitTime*Time.deltaTime);
			goingBack = true;
        }
        else if (goingBack) {
            transform.position = Vector3.MoveTowards(transform.position, rbStart.position,
                speed * Time.deltaTime);
//			yield return new WaitUntil( () => rb.velocity == Vector3.zero);
			yield return new WaitForSecondsRealtime(moveTime + waitTime);
			goingBack = false;
        }
    }

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Player") {
			coll.transform.parent = this.transform;
		}
	}
	void OnCollisionExit(Collision coll){
		if (coll.gameObject.tag == "Player") {
			coll.transform.parent = null;
		}
	}
}
