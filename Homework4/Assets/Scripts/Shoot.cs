using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera viewCamera;
    public Robot robot;
    public Grenade grenade;

    public Bullet bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

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

        var projectile = robot.projectile[robot.current].bullet;
        GameObject currentBullet = Instantiate(robot.bullet[robot.current], position, Quaternion.identity);
        currentBullet.transform.forward = dirWithoutSpread.normalized;
        projectile.Shoot(currentBullet,dirWithoutSpread);
        
        // curBul.grenade.Shoot(currentBullet,dirWithoutSpread);
        // curBul.bullet.Shoot(currentBullet,dirWithoutSpread);
        // curBul.tennis.Shoot(currentBullet,dirWithoutSpread);
    }
}