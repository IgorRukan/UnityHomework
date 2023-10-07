using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shoot : MonoBehaviour
{
    public Camera viewCamera;
    public Robot robot;
    public Grenade grenade;

    public Bullet bullet;
    public Tennis tennis;

    public float shootForce;
    private GameObject currentBullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        if (robot.bullet[robot.current].name.Equals(bullet.name))
        {
            currentBullet = bullet.BulletShooting(viewCamera, robot);
        }
        if (robot.bullet[robot.current].name.Equals(tennis.name))
        {
            currentBullet = tennis.TennisShooting(viewCamera, robot);
        }
        if(robot.bullet[robot.current].name.Equals(grenade.name))
        {
            currentBullet = grenade.GrenadeShooting(viewCamera, robot);
            StartCoroutine(Caboom());
            StartCoroutine(Clean());
        }
        
        StartCoroutine(DeleteBullet());
    }

    IEnumerator Clean()
    {
        int i = 0;
        yield return new WaitForSeconds(3f);
        while (grenade.boom.piecesList.Length != i)
        {
            Destroy(grenade.boom.piecesList[i]);
            i++;
        }
    }
    public IEnumerator Caboom()
    {
        Debug.Log("Boom");
        yield return new WaitForSeconds(1f);
        grenade.boom.Explosion(currentBullet);
        Destroy(currentBullet);
    }
    IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(currentBullet);
    }
}