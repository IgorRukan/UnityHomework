using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Grenade : MonoBehaviour
{
    public float shootForce;
    public Boom boom;

    
    public void Shoot(GameObject currentBullet, Vector3 dirWithoutSpread)
    {
        Debug.Log("grenade");

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithoutSpread.normalized * shootForce, ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.name != "Robot")
        {
            boom.Explosion(gameObject);
            Destroy(gameObject);
        }
    }
}