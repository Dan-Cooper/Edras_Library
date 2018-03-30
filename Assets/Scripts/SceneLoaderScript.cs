using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{

	public bool OnPress;

	private bool _next;

	private void FixedUpdate()
	{
		if (OnPress && Input.GetButton("Jump"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

		}
	}

	private void OnTriggerEnter(Collider other)
	{
		_next = true;
	}

	private void OnTriggerStay(Collider other)
	{
		if (!OnPress && _next)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		_next = false;
	}

}
