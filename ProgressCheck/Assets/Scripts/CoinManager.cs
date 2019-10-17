using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text textbox;
    public int Coins;

    void Start()
    {
        textbox = GetComponent<Text>();
    }

    void Update()
    {
        int Coins = GameObject.Find("Player").GetComponent<PlusMinus>().Coins;

        textbox.text = "" + Coins;
    }
}
