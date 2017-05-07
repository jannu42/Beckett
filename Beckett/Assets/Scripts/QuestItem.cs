using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Quest item script.
/// </summary>

public class QuestItem : MonoBehaviour {

	public int questNumber;

	private QuestManager theQM;
    public int amount;
	public string itemName;
    static int score = 0;
    //public float offsetY;
    //public float offsetX;
    //public float sizeX;
    //public float sizeY;
    public int coinValue;
    public int rareLoot;

    // Use this for initialization
    void Start () {
		theQM = FindObjectOfType<QuestManager> ();
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnGUI()
    {
        //GUI.Box(new Rect(offsetX, offsetY, sizeX, sizeY), "x " +score);
        //GUI.Box(new Rect(552, 9, 31, 25), "x " + score);
        GUI.Box(new Rect(Screen.width - 220, 9, 31, 25), "x " + score);
    }
    /// <summary>
    /// Handles drop rates and values for coin drops from enemies.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			if (!theQM.questCompleted [questNumber] && theQM.quests [questNumber].gameObject.activeSelf) {
                rareLoot = Random.Range(1, 15);
                amount = Random.Range(1, 3);
                theQM.itemCollected = itemName;
				gameObject.SetActive (false);
                coinValue = amount;
                score += coinValue;
                if (rareLoot == 5) {
                    score += 10;
                }
                
			}
		}
	}
}
