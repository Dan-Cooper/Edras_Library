using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {
	private Rigidbody rb;
	public Rigidbody rbStart;
	public Rigidbody rbEnd;	// EndPlatform will move with parent gameobject after Start function

	public float speed;
	[Tooltip("wait time is in seconds")]
	public float waitTime;

	private bool goingBack;

	void Start () {
		rb = GetComponent<Rigidbody>();
		goingBack = false;
	}

	void FixedUpdate () {
		if(!goingBack) {
			transform.position = Vector3.MoveTowards(transform.position, rbEnd.position,
				speed * Time.deltaTime);
			goingBack= true;
		}
		else if(goingBack) {
			transform.position = Vector3.MoveTowards(transform.position, rbStart.position,
				speed * Time.deltaTime);
			goingBack = false;
		}
//		if(!goingBack) {
//			StartCoroutine(ToGoOrNotToGoBack());
//		}
//		else if(goingBack) {
//			StartCoroutine(ToGoOrNotToGoBack());
//		}
	}

//	IEnumerator ToGoOrNotToGoBack() {
//		if(!goingBack) {
//			transform.position = Vector3.MoveTowards(transform.position, rbEnd.position,
//				speed * Time.deltaTime);
//			goingBack= true;
//		}
//		else if(goingBack) {
//			transform.position = Vector3.MoveTowards(transform.position, rbStart.position,
//				speed * Time.deltaTime);
//			goingBack = false;
//		}
//		yield return null;
//	}

}
