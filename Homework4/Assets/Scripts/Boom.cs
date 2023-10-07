using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boom : MonoBehaviour
{
    public GameObject[] piecesList = new GameObject[6];
    public GameObject prefab;
    public float explosionForce;
    public float explosionSpeed;
    public Transform explosionPoint;

    void Update()
    {
        transform.Translate(0, 0, explosionSpeed * Time.deltaTime);
    }
    public void Explosion(GameObject grenade)
    {
        float rotate = 0f;
        int i = 0;
        do
        {
            var position = grenade.transform.position;
            GameObject pieces = Instantiate(prefab, position, Quaternion.identity);
            piecesList[i] = pieces;
            prefab.GetComponent<Rigidbody>().AddForce(position * explosionForce, ForceMode.Force);
            i++;
            rotate += 30f;
            grenade.transform.rotation = Quaternion.identity;

        } while (i < piecesList.Length);
    }
}
