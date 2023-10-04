using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{
    private GameObject point;

    public void ChangePosition(string tag)
    {
        point = GameObject.FindGameObjectWithTag(tag);
        transform.position = point.transform.position;
        transform.rotation = point.transform.rotation;
    }
}
