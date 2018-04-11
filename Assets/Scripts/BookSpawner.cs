using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BookSpawner : MonoBehaviour
{

	public GameObject Book;

	public float Speed;



	private bool _spawn;
	

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(Timer());
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if(_spawn)BookSpawn();
	}

	void BookSpawn()
	{
		GameObject book = Instantiate(Book, transform.position, transform.rotation);
		book.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Speed);
	}
	
	IEnumerator Timer ()
	{   
		print("Reached the target.");
		_spawn = false;
		yield return new WaitForSeconds(1f);
		_spawn = true;
        
		print("routine is now finished.");
	}
}
