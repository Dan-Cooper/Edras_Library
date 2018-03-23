using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Collections;

public class Turret : MonoBehaviour
{
	public GameObject Player;
	[SerializeField]private GameObject _head;
	[SerializeField]private GameObject _body;
	[SerializeField]private GameObject _light; 	//Used for Debug
	private RaycastHit _hit;					//Array of objects in the SphereCast
	public float Range = 10;
	public float Speed = 1;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Detect()) Track(); //Debug.Log("Found Player");

		if (true)
		{
			Vector3 headpos = _head.transform.position;
			Vector3 detection = _head.transform.forward * Range;
			Debug.DrawRay(headpos, detection, Color.magenta); //Mid Forword
			if(_hit.distance <= Range) Debug.DrawRay(headpos, Player.transform.position - headpos,Color.red, 0.1f);
			if(_hit.distance >= Range) Debug.DrawRay(headpos, Player.transform.position - headpos,Color.green);
			//Debug.DrawRay(_head.GetComponent<Transform>().position, _head.GetComponent<Rigidbody>().position+ new Vector3(5,0,0), Color.green);
			//Debug.DrawRay(detection, Player.transform.position, Color.magenta); //Mid Forword
		}
	}

	bool Detect()
	{
		Physics.Raycast(_head.transform.position, Player.transform.position - _head.transform.position, out _hit);
		//Debug.Log("Distince = "+ (int) _hit.distance);

		if (_hit.distance <= Range)
		{
			_light.GetComponent<Light>().color = new Color(255,0,0,255);//TODO Add componet to wake/sleep funtion
			return true;
		}

		else
		{
			_light.GetComponent<Light>().color = new Color(255, 255, 255, 255);//TODO Add componet to wake/sleep funtion
			return false;
		}

	}

	void Track() //TODO fix angle of head.
	{
		Quaternion lookAt = Quaternion.LookRotation(_hit.point - _head.transform.position);

		float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;
		
		Quaternion rotateion = Quaternion.AngleAxis(-angle, Vector3.down);
		
		Debug.Log(lookAt + " : " + angle);
		
		_head.transform.rotation = Quaternion.Slerp(_head.transform.rotation, rotateion, Speed * Time.deltaTime);
		
	}
}
