using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    public float speed;
    public float shootForce;

    public void Shoot(GameObject currentBullet, Vector3 dirWithoutSpread)
    {
        Debug.Log("bulet");
    
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithoutSpread.normalized * shootForce, ForceMode.Impulse);
    
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}