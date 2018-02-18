// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSpawning : MonoBehaviour {
	public GameObject ramp;
	public GameObject rampGuideObj;
	public Transform playerTransform;
	public Transform cameraTransform;	//unused?
	public Transform whereRampSpawns;
	public int maxRamps;

	private GameObject guideInst;

//	public int rampTag;
	/*	0 = platform spawning disabled
	 *	1 = spawn ramp
	 *	2 = spawn floor
	 *	3 = spawn wall
	 *	4 = spawn lift
	 *	any other # = error
	*/

	[SerializeField]
	private int currentRamps;
	[SerializeField]
	private bool prepareRamp;

	void Start () {
		prepareRamp = false;
	}
	
	void Update () {
		if (Input.GetButtonDown("Summon")){

			if (prepareRamp) {
				// then delete rampGuide instance
				Destroy(guideInst);
//				rampInst =
				Instantiate(ramp
					, whereRampSpawns.position
					, playerTransform.rotation
				);

				prepareRamp = false;
				Debug.Log("Is prepareRamp false? " + prepareRamp);
			}
			else if((currentRamps < maxRamps) && !prepareRamp){
				Debug.Log("get button successs!");
				guideInst = 
				Instantiate(rampGuideObj
					, whereRampSpawns.position
					, playerTransform.rotation
					, playerTransform
				);

				currentRamps += 1;
				prepareRamp = true;
				Debug.Log("Is prepareRamp true? " + prepareRamp);
			}



		}


	}



}
