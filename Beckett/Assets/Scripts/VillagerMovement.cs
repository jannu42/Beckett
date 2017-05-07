using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Villager movement script
/// </summary>
public class VillagerMovement : MonoBehaviour {

	public float moveSpeed;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;

	private Rigidbody2D VillagerRigidBody;

	public bool isWalking;

	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	private int WalkDirection;

	public Collider2D walkZone;
	private bool hasWalkZone;

	public bool canMove;
	private DialogManager theDM;

	private Animator anim;

	// Use this for initialization
	void Start () {
		VillagerRigidBody = GetComponent<Rigidbody2D> ();
		theDM = FindObjectOfType<DialogManager> ();
		anim = GetComponent<Animator> ();

		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection ();

		//checks if npc has a walkZone and assigns bounds if there is
		if (walkZone != null) {
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
			hasWalkZone = true;
		}

		//sets npc movement to true at start
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {

		//when dialog box isn't active, npc can move
		if (!theDM.dialogActive) {
			canMove = true;
		}

		//when npc can't move, the speed is set to zero
		if (!canMove) {
			VillagerRigidBody.velocity = Vector2.zero;
			return;
		}

		//when npc isn't moving, set animation direction int to 4 -> idle animation
		if (!isWalking) {
			anim.SetInteger ("Direction", 4);
		}

		if (isWalking) {
			walkCounter -= Time.deltaTime;

			//When walk direction is chosen, goes to corresponding case and sets speed,
			//animator is given the correct direction int and checks if npc is 
			//within its walk zone.
			//case 0: npc moves up
			//case 1: npc moves right
			//case 2: npc moves down
			//case 3: npc moves left
			switch (WalkDirection) {
			case 0:
				VillagerRigidBody.velocity = new Vector2 (0, moveSpeed);
				anim.SetInteger ("Direction", 0);
				if (hasWalkZone && transform.position.y > maxWalkPoint.y){
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 1:
				VillagerRigidBody.velocity = new Vector2 (moveSpeed, 0);
				anim.SetInteger ("Direction", 1);
				if (hasWalkZone && transform.position.x > maxWalkPoint.x){
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 2:
				VillagerRigidBody.velocity = new Vector2 (0, -moveSpeed);
				anim.SetInteger ("Direction", 2);
				if (hasWalkZone && transform.position.y < minWalkPoint.y){
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 3:
				VillagerRigidBody.velocity = new Vector2 (-moveSpeed, 0);
				anim.SetInteger ("Direction", 3);
				if (hasWalkZone && transform.position.x < minWalkPoint.x){
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			}
				
			if (walkCounter < 0) {
				isWalking = false;
				waitCounter = waitTime;
			}

		} else {
			waitCounter -= Time.deltaTime;

			VillagerRigidBody.velocity = Vector2.zero;

			if (waitCounter < 0) {
				ChooseDirection ();
			}
		}
			
	}
		
	/// <summary>
	/// Chooses a direction
	/// A random number between 0 and 4
	/// 0=up 1=right 2=down 3=left
	/// </summary>
	public void ChooseDirection(){
		WalkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;
	}
}
