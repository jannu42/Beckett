using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour {

    public int MaxHealth;
    public int CurrentHealth;
    public GameObject Loot;
    public GameObject HealingItem;
    public int random;
    public Slider EnemySlider;
    //public List<Transform> items = new List<Transform>(); // k

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;
        Loot = GameObject.Find("Loot");
        HealingItem = GameObject.Find("HealingItem");
        //Loot.SetActive(false);
    }

    // Update is called once per frame
    /// <summary>
    /// When enemy dies, it drops a coin (value varies) and a healing item with 50% chance.
    /// </summary>
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            Loot.SetActive(true);
            Instantiate(Loot, transform.position, Quaternion.identity);
            random = Random.Range(1, 3);
            print(random);
            if (random == 2)
            {
                HealingItem.SetActive(true);
                Vector3 spawn = transform.position + new Vector3(3, 2, 0);
                Instantiate(HealingItem, spawn, Quaternion.identity);
            }
        }

    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
        EnemySlider.value = CurrentHealth;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }


}
