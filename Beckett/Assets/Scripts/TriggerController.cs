using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script for changing the scene when trigger is activated
/// </summary>
public class TriggerController: MonoBehaviour {

	public string loadLevel;

	/// <summary>
	/// Checks if trigger zone is entered and loads a new scene
	/// which can be different for every trigger
	/// </summary>
	/// <param name="col">Col.</param>
	public void OnTriggerEnter2D (Collider2D col){
		if (col.CompareTag("Player")){
			SceneManager.LoadScene (loadLevel);
		}
	}
}
