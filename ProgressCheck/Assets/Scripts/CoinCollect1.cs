using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinCollect1 : MonoBehaviour
{
    public int Coins = 0;
    int initialCoins = 0;
    public int neededCoins = 10;
    public Text coinText;

    void Start()
    {
        coinText.text = "Coins: " + Coins + "/" + neededCoins;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Coins++;
            coinText.text = "COINS: " + Coins + "/" + neededCoins;
            Destroy(collision.gameObject);

            if(Coins >= neededCoins)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
            void Update()
    {
        
    }
}
