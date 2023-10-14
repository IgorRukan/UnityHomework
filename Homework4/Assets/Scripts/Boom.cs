using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Boom : MonoBehaviour
{
    public GameObject prefab;
    public float explosionForce;
    public float explosionSpeed;
    public int numberOfPieces = 20;
    private GameObject pieces;
    public GameObject[] piecesList;

    void FixedUpdate()
    {
        transform.Translate(0, 0, explosionSpeed * Time.deltaTime);
    }

    public void Explosion(GameObject grenade)
    {
        // piecesList = new GameObject[numberOfPieces];
        // float rotateX = 0f;
        // float rotateY = 0f;
        // float rotate = 1;
        // int i = 0;
        // do
        // {
        //     if (i*2<=numberOfPieces)
        //     {
        //         rotateX += rotate;
        //         rotateY = 0;
        //     }
        //     else
        //     {
        //         rotateY += rotate;
        //         rotateX = 0;
        //     }
        //     var position = grenade.transform.position;
        //     GameObject pieces = Instantiate(prefab, position, Quaternion.identity);
        //     piecesList[i] = pieces;
        //     pieces.transform.rotation = Quaternion.FromToRotation(Vector3.up,transform.up);
        //     pieces.GetComponent<Rigidbody>().AddForce(position * explosionForce, ForceMode.Force);
        //     i++;
        //     rotate += 30f;
        // } while (i < numberOfPieces);
        Collider[] test = Physics.OverlapSphere(grenade.transform.position,5f);
        foreach (var t in test)
        {
            var rb = t.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(1000f,grenade.transform.position,5f);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.name.Equals("Plane"))
        {
            Debug.Log(other.transform.name);
            Destroy(gameObject);
        }
    }
}