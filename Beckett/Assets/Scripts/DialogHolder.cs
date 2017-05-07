using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dialog holder.
/// </summary>
public class DialogHolder : MonoBehaviour {

	public string dialog;
	private DialogManager dMan;

	public string[] dialogLines;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// Checks if gameobject named "Player" enters trigger area and if space key is pressed
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.name == "Player") {
			if (Input.GetKey (KeyCode.Space)) {
				//dMan.ShowBox (dialog);

				// if dialog isn't active already, resets current lines and shows dialog box
				if (!dMan.dialogActive) {
					dMan.dialogLines = dialogLines;
					dMan.currentLine = 0;
					dMan.ShowDialog();
				}

				//Stops the NPC from moving and animating if dialog is active
				if (transform.parent.GetComponent<VillagerMovement> () != null) {
					transform.parent.GetComponent<VillagerMovement> ().canMove = false;
					transform.parent.GetComponent<Animator> ().SetInteger ("Direction", 4);
				}
			}
		}
	}
}
