// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSpawning : MonoBehaviour {

	public int maxRamps;

	[Space]

	[Header("0 = spawn ramp")]
	[Header("1 = spawn floor")]
	[Header("2 = spawn wall")]
	[Header("3 = spawn lift")]
	[Header("any other # = error")]
	[Header("Size should be 4.")]
	public GameObject[] ramp;
	public GameObject[] rampGuideObj;

	[Space]

	public Transform playerTransform;
	public Transform whereRampSpawns;
	private GameObject guideInst;
	//	public Transform cameraTransform;	//unused?

	[Space]

	[Header("Variables below used just for")]
	[Header("    reference")]	// They will be reset at Start()
	public bool rampEnable;
	[SerializeField]	private bool prepareRamp;
	[SerializeField]	private int rampTag;	// for the array
	[SerializeField]	private int currentRamps;



	void Start () {
		rampEnable = true;
		prepareRamp = false;
		rampTag = 0;
		currentRamps = 0;
	}
	
	void Update () {
		if(rampEnable){

			if(Input.GetButtonDown("Switch Plat")){
				// assign ramp# based on rampTag
				if(rampTag>=0 && rampTag <=3){
					rampTag +=1;
				}
				else if(rampTag == 4){
					rampTag = 0;
				}
			}
				
			if (Input.GetButtonDown("Summon Plat")){

		
				if (prepareRamp) {

					Destroy(guideInst);	// deletes rampGuide instance
	//				rampInst =

					//	if not cancelled or switched
					Instantiate(ramp[rampTag]
						, whereRampSpawns.position
						, playerTransform.rotation
					);
					// "if switched" go here
					// "if cancellled" go here

					prepareRamp = false;
					Debug.Log("Is prepareRamp false? " + prepareRamp);
				}
				else if((currentRamps < maxRamps) && !prepareRamp){
					Debug.Log("get button successs!");
					guideInst = 
					Instantiate(rampGuideObj[rampTag]
						, whereRampSpawns.position
						, playerTransform.rotation
						, playerTransform
					);

					currentRamps += 1;
					prepareRamp = true;
					Debug.Log("Is prepareRamp true? " + prepareRamp);
				}

				else {
					Debug.Log("Some error.");
				}

			}

		}

		else {	//	When ramp spawning is disabled.
			Debug.Log("Ramp spawning disabled. :3");
		}




	}



}
