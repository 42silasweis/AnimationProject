using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 2.0f;
    public float paceSpeed = 1.5f;
    public float paceDistance = 3.0f;
    public float chaseTriggerDistance = 5.0f;
    public Vector2 paceDirection;
    Vector3 startPosition;
    bool home = true;
    void Start()
    {
        startPosition = transform.position;

    }
    // This is not nonsense code right?
    void Update()
    {
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        if(chaseDirection.magnitude < chaseTriggerDistance)
        {
            Chase();
        }else if (!home)
        {
            GoHome();
        }
        else
        {
            Pace();
        }
    }

    void Chase() // Chase function
    {
        home = false;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        chaseDirection.Normalize();
        transform.up = chaseDirection;
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
    }
    void GoHome() // Go back to home function
    {
        Vector2 homeDirection = new Vector2(startPosition.x - transform.position.x, startPosition.y - transform.position.y);
        if(homeDirection.magnitude < 0.1f)
        {
            transform.position = startPosition;
            home = true;
        }
        else
        {

            homeDirection.Normalize();
            transform.up = homeDirection;
            GetComponent<Rigidbody2D>().velocity = homeDirection * paceSpeed;
        }
    }
    void Pace() // Pace when no player is nearby and when at home
    {
        Vector3 displacement = transform.position - startPosition;
        if(displacement.magnitude >= paceDistance)
        {
            paceDirection = -displacement;
        }
        paceDirection.Normalize();
        transform.up = paceDirection;
        GetComponent<Rigidbody2D>().velocity = paceDirection * paceSpeed;
    }
}
