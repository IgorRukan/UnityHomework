using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public float movementSpeed;

    public float rotationSpeed;

    private Rigidbody body;

    public GameObject[] bullet;
    public Projectile[] projectile;
    
    public int current = 0;
    
    public Transform spawnBullet;

    public Vector3 [] vievPort;
    
    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float sideForce = Input.GetAxis("Horizontal") * rotationSpeed;
        if (sideForce != 0.0f)
        {
            body.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }

        float forwardForce = Input.GetAxis("Vertical") * movementSpeed;
        if (forwardForce != 0.0f)
        {
            body.velocity = body.transform.forward * forwardForce;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < bullet.Length; i++)
        {
            if (other.name.Equals(bullet[i].name))
            {
                current = i;
                Debug.Log(bullet[current].name);
            }
        }
    }
}