// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSpawning : MonoBehaviour {

	public int maxRamps;

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

			if (Input.GetButtonDown("Summon Plat")){

		
				if (prepareRamp) {

					Destroy(guideInst);	// deletes rampGuide instance
										// assigned in the "else if" below
	//				rampInst =

					//	if not cancelled or switched
					Instantiate(ramp[rampTag]
						, whereRampSpawns.position		// fix this
						, playerTransform.rotation
					);
												// Ctrl + F add sound here
					// "if switched" go here
					// "if cancellled" go here

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
				guideInst.transform.position += new Vector3(0f, 0f,
					Input.GetAxis("Mouse ScrollWheel")*10f);
				Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
			}
			// ################################"Mouse ScrollWheel"
			//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^			
		}

		else {	//	When ramp spawning is disabled.
			Debug.Log("CN: Ramp spawning disabled. :3");
		}




	}



}
