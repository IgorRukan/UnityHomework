using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera viewCamera;
    public Robot robot;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Shooting()
    {
        Ray ray = viewCamera.ViewportPointToRay(robot.vievPort[robot.current]);
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

        var bullet = robot.bullets[robot.current];
        GameObject currentBullet = Instantiate(bullet.gameObject, position, Quaternion.identity);
        currentBullet.transform.forward = dirWithoutSpread.normalized;
        switch (robot.current)
        {
            case 0:
            {
                bullet.GetComponent<Bullet>().Shoot(currentBullet,dirWithoutSpread);
                return;
            }
            case 1:
            {
                bullet.GetComponent<Grenade>().Shoot(currentBullet,dirWithoutSpread);
                return;
            }
            case 2:
            {
                bullet.GetComponent<Tennis>().Shoot(currentBullet,dirWithoutSpread);
                return;
            }
            default:
            {
                return;
            }
        }
    }
}