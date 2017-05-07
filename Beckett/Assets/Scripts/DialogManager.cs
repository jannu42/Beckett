using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dialog manager.
/// </summary>
public class DialogManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	public bool dialogActive;

	public string[] dialogLines;
	public int currentLine;

	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//adds 1 to currentline variable everytime space is pressed in dialog
		if (dialogActive && Input.GetKeyUp(KeyCode.Space)) {
			// dBox.SetActive (false);
			// dialogActive = false;

			currentLine++;
		}

		//resets current lines when dialog is completed
		if (currentLine >= dialogLines.Length) {
			dBox.SetActive (false);
			dialogActive = false;

			currentLine = 0;
			thePlayer.canMove = true;
		}

		dText.text = dialogLines [currentLine];
	}

	/// <summary>
	/// Shows the dialog box.
	/// </summary>
	/// <param name="dialog">Dialog.</param>
	public void ShowBox(string dialog){
		dialogActive = true;
		this.dBox.SetActive (true);
		this.dText.text = dialog;
	}

	/// <summary>
	/// Better way to activate dialog box
	/// </summary>
	public void ShowDialog(){
		dialogActive = true;
		this.dBox.SetActive (true);
		thePlayer.canMove = false;
	}
}
