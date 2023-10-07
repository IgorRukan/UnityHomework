using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed;
    public float shootForce;

    void Update()
    {
        transform.Translate(0,0,speed*Time.deltaTime);
    }


    public GameObject BulletShooting(Camera viewCamera, Robot robot)
    {
        Debug.Log("bulet");
        Ray ray = viewCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100f);
        }

        var position = robot.spawnBullet.position;
        Vector3 dirWithoutSpread = (targetPoint - position);

        GameObject currentBullet = Instantiate(robot.bullet[robot.current], position, Quaternion.identity);

        currentBullet.transform.forward = dirWithoutSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithoutSpread.normalized * shootForce, ForceMode.Impulse);

        return currentBullet;
    }

    private void OnTriggerEnter(Collider other)
     {
         if (other.name.Contains("Wall"))
         {
             Debug.Log(other.name);
            Destroy(this.gameObject);   
         }
     }
}

