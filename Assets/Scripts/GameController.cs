// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	[Header("For now, press R to reset scene.")]
	[Header("      Or whatever button you assign ")]
	[Header("      to 'Reset' in the InputManager.")]

	[Space]
	public string dummyVariable;

	void Update () {
		if(Input.GetButtonUp("Reset")) {
			//	reload scene for now
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}
	}
}
