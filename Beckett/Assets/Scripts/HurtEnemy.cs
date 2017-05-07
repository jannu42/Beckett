using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {


    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;
    public GameObject HitPoint;
    //private PlayerController player;

	// Use this for initialization
	void Start () {
        //player = new PlayerController();
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    /// <summary>
    /// Damages the enemy with 10 to 20 damage if "J" button is pressed. Plays damage number and "hitsplat" on screen.
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter2D(Collider2D other)
    { 
            if (other.gameObject.tag == "Enemy")
            {
                damageToGive = Random.Range(10, 21);
                HitPoint = GameObject.Find("HitPoint");
                HitPoint.SetActive(true);
                other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
                Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
                var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
            }
        
    }
}
