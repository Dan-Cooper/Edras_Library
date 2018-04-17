// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {
	
	[Header("Remember to freeze rotation!")]
	public Rigidbody platRb;	// remember to freeze rotaion

	[Header("Just tells the direction to go.")]
	[Header("      distance = speed * time")]
	public Transform endPoint;	//tells direction
	private Vector3 endPointVector;

	public float speed;
	public int goInDirectionForSeconds;
	private int platTime;

	private bool goForward;


	void Start () {
		goForward = true;
		platTime = 1;	// not 0, so it doesn't trigger at beginning
		endPointVector = endPoint.position.normalized;
	}

	void FixedUpdate () {
		if(platTime <= 0) {	// with <= failsafe
			goForward = true;
		}
		else if(platTime >= goInDirectionForSeconds*60) {	// with >= failsafe
			goForward = false;
		}

		if(goForward) {
			platRb.velocity = speed*endPointVector;
			platTime += 1;
		}
		else if(!goForward) {
			platRb.velocity = -speed*endPointVector;
			platTime -= 1;
		}

	}
	void OnCollisionStay(Collision other) {
		if(other.gameObject.tag == "Player") {
			
		}
	}
//	void OnCollisionEnter(Collision coll){
//		Debug.Log("err 1a");
//		if (coll.gameObject.tag == "Player") {
//			coll.transform.parent = platRb.transform;
//			Debug.Log("err 1b");
//		}
//	}
//	void OnCollisionExit(Collision coll){
//		Debug.Log("err 2a");
//		if (coll.gameObject.tag == "Player") {
//			coll.transform.parent = null;
//			Debug.Log("err 2b");
//		}
//	}

}

//	public Rigidbody rbStart;
//	public Rigidbody rbEnd;	// EndPlatform will move with parent gameobject after Start function
//
//	public float speed;
//	[Tooltip("wait time is in seconds")]
//	public float waitTime;
//	private float moveTime;
//
//	[SerializeField]
//	private bool goingBack;
//
//	void Start () {
//		moveTime = speed;
//		goingBack = false;
//		Debug.Log("moveTime = " + moveTime);
//
//	}
//
//	void FixedUpdate () {
//		StartCoroutine(PlatformNowMove());
//	}
//
//	IEnumerator PlatformNowMove() {
//        if (!goingBack) {
//            transform.position = Vector3.MoveTowards(transform.position, rbEnd.position,
//                speed * Time.deltaTime);
////			yield return new WaitUntil( () => rb.velocity == Vector3.zero);
//			yield return new WaitForSecondsRealtime(moveTime + waitTime*Time.deltaTime);
//			goingBack = true;
//        }
//        else if (goingBack) {
//            transform.position = Vector3.MoveTowards(transform.position, rbStart.position,
//                speed * Time.deltaTime);
////			yield return new WaitUntil( () => rb.velocity == Vector3.zero);
//			yield return new WaitForSecondsRealtime(moveTime + waitTime);
//			goingBack = false;
//        }
//    }
