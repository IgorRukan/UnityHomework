using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Grenade : MonoBehaviour
{
    public float shootForce;
    public float speed;
    public Boom boom;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }


    public GameObject GrenadeShooting(Camera viewCamera, Robot robot)
    {
        Debug.Log("grenade");
        Ray ray = viewCamera.ViewportPointToRay(new Vector3(0.5f, 0.8f, 0));
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
    
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.collider.enabled)
    //     {
    //         Destroy(this);
    //         // boom.Explosion(this.transform.position);   
    //     }
    // }
}