using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tennis : MonoBehaviour
{
    
    public float shootForce;
    public float speed;

    void Update()
    {
        transform.Translate(0,0,speed*Time.deltaTime);
    }


    public GameObject TennisShooting(Camera viewCamera,Robot robot)
    {
        Debug.Log("tenis");
        Ray ray = viewCamera.ViewportPointToRay(new Vector3(0.5f, 0.9f, 0));
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

        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithoutSpread.normalized * shootForce, ForceMode.Force);

        return currentBullet;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.name.Contains("Wall"))
        // {
        //     Destroy(this.gameObject);   
        // }
    }
}
