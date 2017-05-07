using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quest trigger script.
/// </summary>

public class QuestTrigger : MonoBehaviour {

	private QuestManager theQM;

	public int questNumber;

	public bool startQuest;
	public bool endQuest;



	// Use this for initialization
	void Start () {
		theQM = FindObjectOfType<QuestManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// Player starts quest if the quest is active.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {			//If player
			if (!theQM.questCompleted [questNumber] ) {		//has not started or done the quest.
				if(startQuest && !theQM.quests[questNumber].gameObject.activeSelf){
					theQM.quests [questNumber].gameObject.SetActive (true);
					theQM.quests [questNumber].StartQuest ();
				}
				if (endQuest && theQM.quests[questNumber].gameObject.activeSelf ) {
				theQM.quests [questNumber].EndQuest ();
				}

			}
		}
	}

}
