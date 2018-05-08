﻿// This is Cathy's baby.

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
	[Space]
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
	[HideInInspector] public bool rampEnable;
	private bool prepareRamp;
	private int rampTag;	// for the arrays
	private int currentRampTotal;
	[Header("Elements below should initially")]
	[Header("      be at zero.")]
	public int[] currentRampByType;


	void Start () {
		playerTransform = GetComponent<Transform>();
		rampEnable = true;
		prepareRamp = false;
		rampTag = 0;
		currentRampTotal = 0;
	}
		
	void Update () {
		if(rampEnable){		
			// Inputs: "Summon Plat", "Switch Plat", "Mouse ScrollWheel", ""
			if (Input.GetButtonDown("Summon Plat")){

				if (prepareRamp) {
					if( (currentRampTotal < maxTotal) 
						&&(currentRampByType[rampTag] < maxByType[rampTag]) ) {
						SummonPlatMethod();
					}
					else{
						Debug.Log("Can't place any more! :(");
					}
				}
				else if(!prepareRamp){
					SummonGuideMethod();
				}
				else {
					Debug.Log("CN: Some ramp spawning error.");
				}
			}
			SwitchPlatMethod();

			if(prepareRamp){
				ScrollPlatMethod();
		
				if(Input.GetButtonDown("Undo Summon")){
					Destroy(guideInst);
					prepareRamp = false;
				}
			}
		}
		else {	//	When disabled
			Debug.Log("CN: Ramp spawning disabled. :3");
		}

	}
	//####################################################################

	void SummonPlatMethod() {
		Destroy(guideInst);	// deletes rampGuide instance

		Instantiate(ramp[rampTag]
			, guideInst.transform.position
			, playerTransform.rotation
		);
		// Ctrl + F add sound here

		currentRampTotal += 1;
		currentRampByType[rampTag] +=1;
		prepareRamp = false;
	}

	void SummonGuideMethod() {
		guideInst = 
			Instantiate(rampGuideObj[rampTag]
				, whereRampSpawns.position
				, playerTransform.rotation
				, playerTransform
				//							, whereRampSpawns
			);
		// Ctrl + F add sound here

		prepareRamp = true;
	}
	//####################################################################

	void SwitchPlatMethod() {
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

			// vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv testing grounds
			Debug.Log(currentRampByType[rampTag] +"=="+ maxByType[rampTag] +"?");
			if(currentRampByType[rampTag] == maxByType[rampTag]) {	// skip if that plat all used
				if(rampTag>=0 || rampTag < arraySize-1){		// repeat code
					rampTag +=1;
				}
				else if(rampTag == arraySize-1){
					rampTag = 0;
				}
				else{
					Debug.Log("Hullo.");
				}
				Debug.Log("xxhcjxhjgkl");

			}
			// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^ testing grounds

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
	}
	//####################################################################

	void ScrollPlatMethod() {
		//Debug.Log(guideInst.transform.localPosition.y);

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
	}
	//####################################################################


}
