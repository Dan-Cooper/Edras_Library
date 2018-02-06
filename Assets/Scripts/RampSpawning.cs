using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampSpawning : MonoBehaviour {
	public GameObject ramp;
	public Transform playerTransform;
	public int maxRamps;
	[SerializeField]
	private int currentRamps;

	void Start () {
		
	}
	
	void Update () {
		if(Input.GetButton("Fire3") && (currentRamps < maxRamps)){
			Debug.Log("get button successs!");
			Vector3 rampSpawnPoint = new Vector3(0f, 0f, 3f);

			Instantiate(ramp, rampSpawnPoint,Quaternion.identity, playerTransform);
			currentRamps += 1;
		}
	}
}
