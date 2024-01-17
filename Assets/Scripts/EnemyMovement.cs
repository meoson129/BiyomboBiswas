using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float enemySpeed = 5f;
    private Vector3 target;

    void Start()
    {
        target = pointA.position; 
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, enemySpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
           
            if (target == pointA.position)
            {
                target = pointB.position;
            }
            else
            {
                target = pointA.position;
            }
        }
    }
}
