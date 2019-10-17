using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyPace : MonoBehaviour
{
    public float paceSpeed = 1.5f;
    public float paceDistance = 3.0f;
    public Vector2 paceDirection;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = transform.position - startPosition;
        if (displacement.magnitude >= paceDistance)
        {
            paceDirection = -displacement;
        }
        paceDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = paceDirection * paceSpeed;
    }
}
