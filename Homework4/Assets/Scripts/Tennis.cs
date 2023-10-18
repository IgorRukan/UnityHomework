using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tennis : MonoBehaviour
{
    public float shootForce;
    public float bounceTime;
    public float bounceTimeLength = 5f;

    private void Start()
    {
        bounceTimeLength *= 2;
    }


    public void Shoot(GameObject currentBullet, Vector3 dirWithoutSpread)
    {
        Debug.Log("tenis");

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithoutSpread.normalized * shootForce, ForceMode.Impulse);

        bounceTime = 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        bounceTime++;
        if (bounceTime >= bounceTimeLength)
        {
            Destroy(gameObject);
        }
    }
}