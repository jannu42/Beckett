using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void NewGameBtn(string newGameLevel){
		SceneManager.LoadScene (newGameLevel);
	}

	/// <summary>
	/// Loads the game settings.
	/// </summary>
	public void LoadGameSettings(string GameLevel){
		SceneManager.LoadScene (GameLevel);
		PlayerPrefs.GetFloat ("x");
		PlayerPrefs.GetFloat ("y");
		PlayerPrefs.GetFloat ("z");
		PlayerPrefs.GetFloat ("Cam_y");
	}

	/// <summary>
	/// Exits the application button.
	/// </summary>
	public void ExitApplicationBtn(){
		Application.Quit ();
	}

	/// <summary>
	/// Exits the game.
	/// </summary>
	/// <param name="Quit">If set to <c>true</c> quit.</param>
	public void ExitGame(bool Quit){
		if (Quit) {
			Time.timeScale = 1;
			SceneManager.LoadScene ("Menu Screen");
		}
	}
}
