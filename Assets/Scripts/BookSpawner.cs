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

	void BookSpawn()
	{
		GameObject book = Instantiate(Book, transform.position, transform.rotation);
		book.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * Speed);
	}
	
	IEnumerator Timer ()
	{   
		print("Reached the target.");
		while (true)
		{
			_spawn = false;
			yield return new WaitForSeconds(1f);
			BookSpawn();
			_spawn = true;
			yield return new WaitForSeconds(1f);

			print("routine is now finished.");
		}
	}
}
