using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    public Vector3 endPoint;
    public Vector3 startPoint;

    public float speed = 2f;

    public bool check = true;
    public bool move = false;

    private void Start()
    {
        startPoint = transform.position;
    }


    void Update()
    {
        if (transform.position.y.Equals(endPoint.y))
        {
            check = false;
            move = false;
        }

        if (transform.position.y.Equals(startPoint.y))
        {
            check = true;
            move = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            move = true;
        }

        if (move)
        {
            if (check)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPoint, speed * Time.deltaTime);
            }
        }
    }
}