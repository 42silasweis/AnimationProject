using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshoot : MonoBehaviour
{
    public GameObject player;
    public GameObject prefab;
    public float bulletSpeed = 10.0f;
    public float bulletlifetime = 1.0f;
    public float shootDelay = 1.0f;
    public float fireRange = 1.0f;
    float timer = 0;
    public Vector2 distance;
    void Start()
    {

    }


    void Update()
    {
        Vector2 playerPosition = player.transform.position;
        distance = player.transform.position - transform.position;
        timer += Time.deltaTime;
        if (distance.magnitude < fireRange && timer > shootDelay)
        {
            timer = 0;
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            Debug.Log(playerPosition);
            Vector2 shootDir = new Vector2(playerPosition.x - transform.position.x, playerPosition.y - transform.position.y);
            shootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir * bulletSpeed;
            Destroy(bullet, bulletlifetime);
        }
    }

}
