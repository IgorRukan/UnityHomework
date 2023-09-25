using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    private float rotate;

    public float speed;
    void Update()
    {
        rotate += speed*Time.deltaTime;
        transform.rotation = Quaternion.Euler(0,rotate,0);
        if (rotate > 360f)
        {
            rotate = 0;
        }
    }
}
