using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Text textbox;
    public int Lives;

    void Start()
    {
        textbox = GetComponent<Text>();
    }

    void Update()
    {
        int Lives = GameObject.Find("Player").GetComponent<PlusMinus>().Lives;

        textbox.text = "" + Lives;
    }
}
