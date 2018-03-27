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
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Detect()) Track();; //Debug.Log("Found Player");

		if (true)
		{
			Vector3 headpos = _head.transform.position;
			Vector3 detection = _head.transform.forward*10;
			Debug.DrawRay(headpos, detection, Color.magenta); //Mid Forword
			if(_hit.distance <=10) Debug.DrawRay(headpos, Player.transform.position - headpos,Color.red, 0.1f);
			if(_hit.distance >=10) Debug.DrawRay(headpos, Player.transform.position - headpos,Color.green);
			//Debug.DrawRay(_head.GetComponent<Transform>().position, _head.GetComponent<Rigidbody>().position+ new Vector3(5,0,0), Color.green);
			//Debug.DrawRay(detection, Player.transform.position, Color.magenta); //Mid Forword
		}
	}

	bool Detect()
	{
		Physics.Raycast(_head.transform.position, Player.transform.position - _head.transform.position, out _hit);
		//Debug.Log("Distince = "+ (int) _hit.distance);

		if (_hit.distance <= 10) return true;
		
		return false;
		
		
		/*//TODO Erase old Spherecast info if all is working.
		//_hits = Physics.SphereCastAll(_head.GetComponent<Transform>().position, 5f, _head.GetComponent<Transform>().position);	//Shoots a ray sphere out to 10 unity units and returns a Raycast hit.
			
		//int i = 0;
		foreach (var hit in _hits)
		{
			if (hit.transform.CompareTag(Player.tag))
			{
				Debug.Log("Distince = "+ (int) hit.distance);
				return true;
			}
			//Debug.Log("Detect Loop " + i);
			//i++;
		}
*/

	}

	void Track()
	{
		_head.transform.LookAt(Player.transform.position, _head.transform.up);//TODO slow sweep to target.
		
		_head.transform.localRotation = new Quaternion(_head.transform.localRotation.x, 0, _head.transform.localRotation.z ,0); //TODO Head upside down fix.
		/*float x;
		float y;

		Quaternion lookAt = Quaternion.LookRotation(_hit.point - _head.transform.position);
		
		Debug.Log(lookAt + " : " + _head.transform.rotation);
		
		_head.transform.Rotate(lookAt.eulerAngles);*/
		
		//Quaternion.Slerp(_head.transform.rotation, lookAt, 0.1f);

		//_head.transform.Rotate((Player.transform.position - _head.transform) * Time.deltaTime);

		/*Vector3 targetRotBody = _head.transform.rotation.eulerAngles;
		

		Vector3 PlayerPos = Player.GetComponent<Transform>().position;
		Debug.Log(PlayerPos);

		Vector3 TurretPos = _head.GetComponent<Transform>().position;
		Debug.Log(TurretPos);

		x = PlayerPos.x - TurretPos.x;
		y = PlayerPos.y - TurretPos.y;
		
		targetRotBody.y += y;
		
		Debug.Log("X: "+x+" Y: "+y);
		_head.GetComponent<Transform>().eulerAngles = new Vector3(x,y,0);
		_head.transform.rotation = Quaternion.Euler(targetRotBody);*/
	}
}
