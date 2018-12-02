using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour {

	public void LoadScene()
	{ 
		// Application.LoadLevel(level);
		SceneManager.LoadScene("Level1", LoadSceneMode.Single);
	}
	public void Exit () {
		Application.Quit();
	}
}