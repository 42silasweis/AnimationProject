using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    float timer = 0;
    public Vector2 moveDir;
    public float moveSpeed = 3.0f;
    public float paceDuratioon = 3.0f;
    public GameObject player;
    public float Range = 10.0f;
    Vector2 OriginPosition;
    public Vector2 distance;
    Vector2 playerDir;
    Vector2 EnememyStartPos;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 OriginPosition = new Vector2 (transform.position.x, transform.position.y);
        moveDir.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= paceDuratioon)
        {
            moveDir *= -1;
            timer = 0;
        }
        GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
        Vector2 playerPosition = player.transform.position;
        distance = player.transform.position - transform.position;
        if (distance.magnitude < Range)
        {
            playerDir = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
            playerDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = playerDir * moveSpeed;
            if (distance.magnitude > Range)
            {
                playerDir.Normalize();
                GetComponent<Rigidbody2D>().velocity = OriginPosition * moveSpeed;
                Debug.Log(OriginPosition);
            }
        }
        
    }
}
