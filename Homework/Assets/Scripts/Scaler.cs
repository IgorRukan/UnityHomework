using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public float x, y, z;

    public float scaleChange;

    private Vector3 scale;

    public float coef = 0.01f;

    void Update()
    {
        scale = new Vector3(x * scaleChange*coef, y * scaleChange*coef, z * scaleChange*coef);
        transform.localScale += scale * Time.deltaTime;
    }
}