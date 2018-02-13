using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSpawning : MonoBehaviour {
	public GameObject ramp;
	public Transform playerTransform;
	public Transform cameraTransform;
	public Transform whereRampSpawns;
	public int maxRamps;
//	public bool rampEnable;		// Set to false to disable ramp spawning

	[SerializeField]
	private int currentRamps;
	[SerializeField]
	private bool holdingRamp;

	void Start () {
		holdingRamp = false;
//		rampEnable = true;
	}
	
	void Update () {
		if (Input.GetButtonDown("Summon")){
			if((currentRamps < maxRamps) && !holdingRamp){
				Debug.Log("get button successs!");
				Instantiate(ramp, whereRampSpawns.localPosition + cameraTransform.position,
					Quaternion.identity
//					, playerTransform
				);

				currentRamps += 1;
				holdingRamp = true;
				Debug.Log("holdingRamp = " + holdingRamp);
			}

			else if (holdingRamp) {
	//			ramp.transform.parent = null;
				holdingRamp = false;
				Debug.Log("holdingRamp = " + holdingRamp);
			}

		}


	}



}
