// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSpawning : MonoBehaviour {

	public int maxRamps;
	public float minDistance = 3f;
	public float maxDistance = 15f;

	[Header("Size should be the same integars.")]
	public int arraySize;
	public GameObject[] ramp;
	public GameObject[] rampGuideObj;

	[Space]

	public Transform whereRampSpawns;
	private Transform playerTransform;
	private GameObject guideInst;

	[Space]

	[Header("Variables below used for enabling")]
	[Header("    and disabling magic platform ")]
	[Header("    spawning")]			// They will be reset at Start()
	public bool rampEnable;
//	[SerializeField]	
	private bool prepareRamp;
//	[SerializeField]	
	private int rampTag;	// for the array
//	[SerializeField]	
	private int currentRamps;

	void Start () {
		playerTransform = GetComponent<Transform>();
		rampEnable = true;
		prepareRamp = false;
		rampTag = 0;
		currentRamps = 0;
	}

	
	void Update () {
		if(rampEnable){
			//vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
			// Inputs: "Summon Plat", "Switch Plat", "Mouse ScrollWheel", ""
			if (Input.GetButtonDown("Summon Plat")){

		
				if (prepareRamp) {

					Destroy(guideInst);	// deletes rampGuide instance

					Instantiate(ramp[rampTag]
						, guideInst.transform.position
						, playerTransform.rotation
					);
												// Ctrl + F add sound here
					prepareRamp = false;
				}
				else if((currentRamps < maxRamps) && !prepareRamp){
					guideInst = 
						Instantiate(rampGuideObj[rampTag]
							, whereRampSpawns.position
							, playerTransform.rotation
							, playerTransform
						);
												// Ctrl + F add sound here

					currentRamps += 1;
					prepareRamp = true;
				}

				else {
					Debug.Log("CN: Some ramp spawning error.");
				}

			}

			if(Input.GetButtonDown("Switch Plat")){
				// assign ramp# based on rampTag
				if(rampTag>=0 && rampTag < arraySize-1){
					rampTag +=1;
				}
				else if(rampTag == arraySize-1){
					rampTag = 0;
				}
				else{
					Debug.Log("Error.");
				}

				if(prepareRamp){
					Destroy(guideInst);
					guideInst =
						Instantiate(rampGuideObj[rampTag]
							, whereRampSpawns.position
							, playerTransform.rotation
							, playerTransform
						);
												// Ctrl + F add sound here
				}
			}
			// ###############################################
			if(prepareRamp){
				guideInst.transform.localPosition += new Vector3(0f, 0f,
					Input.GetAxis("Mouse ScrollWheel")*10f);
				
				if(guideInst.transform.localPosition.z <= minDistance){	// minimum distance from player
					guideInst.transform.localPosition = 
						new Vector3(0f,whereRampSpawns.position.y,minDistance);
				}
				if(guideInst.transform.localPosition.z >= maxDistance){	// maximum distance from player
					guideInst.transform.localPosition = 
						new Vector3(0f,whereRampSpawns.position.y,maxDistance);
				}

//				Debug.Log(guideInst.transform.localPosition);

				if(Input.GetButtonDown("Undo Summon")){
					Destroy(guideInst);
					prepareRamp = false;
				}

			}
			// ################################"Mouse ScrollWheel"
			//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^			
		}

		else {	//	When ramp spawning is disabled.
			Debug.Log("CN: Ramp spawning disabled. :3");
		}




	}



}
