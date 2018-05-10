using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BookSpawner : MonoBehaviour
{

	public GameObject Book;

	public GameObject Book2;

	public GameObject Book3;

	public float Speed;

	private bool _spawn;

	private Random rand = new Random();
	private float ranumb = 1;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(Timer());

	}

	void BookSpawn()
	{
		if (ranumb <= 0.3) {
			GameObject book = Instantiate (Book, transform.position, transform.rotation);
			book.GetComponent<Rigidbody> ().velocity = transform.TransformDirection (Vector3.forward * Speed);
		} else if (ranumb <= 0.6){
			GameObject book = Instantiate (Book2, transform.position, transform.rotation);
			book.GetComponent<Rigidbody> ().velocity = transform.TransformDirection (Vector3.forward * Speed);
		} else {
			GameObject book = Instantiate (Book3, transform.position, transform.rotation);
			book.GetComponent<Rigidbody> ().velocity = transform.TransformDirection (Vector3.forward * Speed);
		}
	}
	
	IEnumerator Timer ()
	{   
		//print("Reached the target.");
		while (true)
		{
			_spawn = false;
			yield return new WaitForSeconds(1f);
			ranumb = Random.value;
			BookSpawn();
			_spawn = true;
			yield return new WaitForSeconds(1f);

			//print("routine is now finished.");
		}
	}
}
