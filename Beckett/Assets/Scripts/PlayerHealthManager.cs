using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {


    public int playerMaxHealth;
    public int playerCurrentHealth;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.4f);
    public Slider healthSlider;
    public GameObject GameOver;
    public GameObject GameOverback;
    public GameObject HealingItem;
    public int HealingItemVal = 20;
    //HealingItem.SetActive(true);
    //Instantiate(HealingItem, transform.position, Quaternion.identity);

    // Use this for initialization
    /// <summary>
    /// Finds all needed components for this class.
    /// </summary>
    void Start () {
        playerCurrentHealth = playerMaxHealth;
        GameOver = GameObject.Find("GameOver");     
        GameOver.SetActive(false);
        GameOverback = GameObject.Find("GameOverBack");
        GameOverback.SetActive(false);
        HealingItem = GameObject.Find("HealingItem");
    }
    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            GameOver.SetActive(true);
            GameOverback.SetActive(true);
            //SceneManager.LoadScene("GameOver");
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        if (playerCurrentHealth > 100) {
            playerCurrentHealth = 100;
        }
    }
        void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "HealingItem") {
            playerCurrentHealth += HealingItemVal;
            other.gameObject.SetActive(false);
            healthSlider.value = playerCurrentHealth;
            
        }
        }
    
	/// <summary>
	/// Hurts the player and sets healthslider to match healthpoints.
	/// </summary>
	/// <param name="damageToGive">Damage to give.</param>
    public void HurtPlayer(int damageToGive)
    {
        damageImage.color = flashColour;
        playerCurrentHealth -= damageToGive;
        healthSlider.value = playerCurrentHealth;
    }

	/// <summary>
	/// Sets the max health.
	/// </summary>
    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
