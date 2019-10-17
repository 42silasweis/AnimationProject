using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollect : MonoBehaviour
{
    public int coinCount = 0;
    public Text coinText;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            coinCount++;
            coinText.text = "Coins: " + coinCount;
            Destroy(collision.gameObject);
        }
    }
}
