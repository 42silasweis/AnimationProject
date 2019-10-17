using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text textbox;
    public int Health;

    void Start()
    {
        textbox = GetComponent<Text>();
    }

    void Update()
    {
        int Health = GameObject.Find("Player").GetComponent<PlusMinus>().Health;

        textbox.text = "" + Health;
    }
}
