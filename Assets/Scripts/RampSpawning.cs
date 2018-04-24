// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSpawning : MonoBehaviour {

	public float minDistance = 3f;
	public float maxDistance = 15f;

	[Space]

	[Header("Magic Platform Limits:")]
	public bool enableMaxByType = false;
	public int[] maxByType;
	public bool enableMaxTotal = true;
	public int maxTotal = 15;

	[Header("Size should be the same integars.")]
	public int arraySize;
	public GameObject[] ramp;
	public GameObject[] rampGuideObj;

	[Space]

	public Transform whereRampSpawns;	// Why 2 transforms?
	private Transform playerTransform;	// Why 2 transforms?
	private GameObject guideInst;

	[Space]

//	[Header("Variables below used for enabling")]
//	[Header("    and disabling magic platform ")]
//	[Header("    spawning")]			// They will be reset at Start()
	[HideInInspector] public bool rampEnable;
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
				else if((currentRamps < maxTotal) && !prepareRamp){
					guideInst = 
						Instantiate(rampGuideObj[rampTag]
							, whereRampSpawns.position
							, playerTransform.rotation
							, playerTransform
//							, whereRampSpawns
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
//							,whereRampSpawns
						);
												// Ctrl + F add sound here
				}
			}
			// #################################"Mouse ScrollWheel"
			if(prepareRamp){
				Debug.Log(guideInst.transform.localPosition.y);

				guideInst.transform.localPosition += new Vector3(0f, 0f,	// scrolling thing
					Input.GetAxis("Mouse ScrollWheel")*10f);
				
				if(guideInst.transform.localPosition.z <= minDistance){		// minimum distance from player
					guideInst.transform.localPosition = 
						new Vector3(0f,whereRampSpawns.position.y,minDistance);
				}
				if(guideInst.transform.localPosition.z >= maxDistance){		// maximum distance from player
					guideInst.transform.localPosition = 
						new Vector3(0f,whereRampSpawns.position.y,maxDistance);
				}
			// ################################


				if(Input.GetButtonDown("Undo Summon")){
					Destroy(guideInst);
					prepareRamp = false;
				}

			}

		}

		else {	//	When ramp spawning is disabled.
			Debug.Log("CN: Ramp spawning disabled. :3");
		}




	}



}
