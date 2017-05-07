using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quest manager.
/// </summary>

public class QuestManager : MonoBehaviour {

	public QuestObject[] quests;
	public bool [] questCompleted;

	public DialogManager theDM;

	public string itemCollected;

	public string enemyKilled;

	private static bool QuestManagerExists;

	// Use this for initialization
	void Start () {

		questCompleted = new bool[quests.Length];

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	/// <summary>
	/// Shows the quest text.
	/// </summary>
	/// <param name="questText">Quest text.</param>
	public void ShowQuestText(string questText){
		theDM.dialogLines = new string[1];
		theDM.dialogLines [0] = questText;

		theDM.currentLine = 0;
		theDM.ShowDialog ();

	}

}
