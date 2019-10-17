using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    public int startingLives;
    private int lifeCounter;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GiveLife()
    {
        lifeCounter++;
    }
    public void TakeLife()
    {
        lifeCounter--;
    }
}
