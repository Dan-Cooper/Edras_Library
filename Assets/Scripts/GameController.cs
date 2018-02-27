// Cathy made this.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	[Header("Press R to reset scene.")]
	[Header("      Or whatever button you assign ")]
	[Header("      to 'Reset' in the InputManager.")]

	[Space]
	public string dummyVariable;

	void Update () {
		if(Input.GetButtonUp("Reset")) {
			//	reload scene for now
//			SceneManager.LoadScene(SceneManager.SetActiveScene());
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}
	}
}
