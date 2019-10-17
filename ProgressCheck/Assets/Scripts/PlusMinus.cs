using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlusMinus : MonoBehaviour
{
    public int Coins = 0;
    public int CoinsToLivesCounter = 0;
    public int CoinsNeededForLives = 5;
    int initialCoins = 0;
    public int neededCoins = 10;
    public int Health = 10;
    int initialHealth;
    public int Lives = 5;
    public Text coinText;
    public Text healthText;
    public Text liveText;
    public Slider healthSlider;
    public LevelManager levelManager;
    void Start()
    {
        initialHealth = Health;
        levelManager = FindObjectOfType<LevelManager>();
        healthSlider.maxValue = Health;
        healthSlider.value = Health;
        coinText.text = "Coins: " + Coins + "/" + neededCoins;
        healthText.text = "HEALTH: " + Health + "/" + initialHealth;
        liveText.text = "LIVES: " + Lives;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyShoot")
        {
            Health--;
            healthSlider.value = Health;
            healthText.text = "HEALTH: " + Health + "/" + initialHealth;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Coin")
            {
            Coins++;
            CoinsToLivesCounter++;
            coinText.text = "COINS: " + Coins + "/" + neededCoins;
            Destroy(collision.gameObject);
            if(CoinsToLivesCounter >= CoinsNeededForLives)
            {
                Lives++;
                CoinsToLivesCounter = initialCoins;
                liveText.text = "LIVES: " + Lives;
            }
            if (Coins >= neededCoins)
                {
                    SceneManager.LoadScene("Win");
                }
            }
        if (collision.gameObject.tag == "Respawn")
        {
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Health--;
            healthSlider.value = Health;
            healthText.text = "HEALTH: " + Health + "/" + initialHealth;
            if (Health < 1)
            {
                Lives--;
                liveText.text = "LIVES: " + Lives;
                Health = initialHealth;
                if (Lives <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                else
                {
                    levelManager.RespawnPlayer();
                    healthSlider.value = Health;
                    healthText.text = "HEALTH: " + Health + "/" + initialHealth;
                }
                //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
      }
    }
