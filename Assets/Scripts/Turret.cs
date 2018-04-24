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
	private RaycastHit _hit;					//
	private RaycastHit _fire;
	public float Range = 10;
	public float Speed = 1;
	public float Damage = 1;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Detect()) 
		{
			Track(); 
			Fire();
		}

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

	void Track()
	{
		Quaternion lookAt = Quaternion.LookRotation(_hit.point - _head.transform.position); //Gets the pos to look at
		Vector3 rotateion = Quaternion.Lerp(_head.GetComponent<Transform>().rotation, lookAt, Speed * Time.deltaTime).eulerAngles; //Sets the actual rotation and speed of turn
		_head.GetComponent<Transform>().rotation = Quaternion.Euler(rotateion.x, rotateion.y, 0f); //Applies effetc to the head.

	}

	void Fire()
	{
		Physics.Raycast(_head.transform.position, _head.transform.forward, out _fire);

		if (_fire.collider.tag.Equals("Player"))
		{
			Player.GetComponent<PlayerControler>().Damage(Damage);
		}
	}
}
