using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour {

	public Transform Player;

	/// <summary>
	/// Saves the game settings.
	/// </summary>
	public void SaveGameSettings(){
		PlayerPrefs.SetFloat ("x", Player.position.x);
		PlayerPrefs.SetFloat ("y", Player.position.y);
		PlayerPrefs.SetFloat ("z", Player.position.z);
		PlayerPrefs.SetFloat ("Cam_y", Player.eulerAngles.y);
	}

	/// <summary>
	/// Loads the game settings.
	/// </summary>
	public void LoadGameSettings(string GameLevel){
		PlayerPrefs.GetFloat ("x");
		PlayerPrefs.GetFloat ("y");
		PlayerPrefs.GetFloat ("z");
		PlayerPrefs.GetFloat ("Cam_y");
		SceneManager.LoadScene (GameLevel);
	}
		
}
