﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon {

    public float spread = 5f;

    public override void Attack()
    {
        // store forward direction of player
        Vector3 direction = transform.forward;
        //Calculate spread by using range
        Vector3 spread = Vector3.zero;
        //Offset on local Y
        spread += transform.up * Random.Range(-accuracy, accuracy);
        //offset on local X
        spread += transform.right * Random.Range(-accuracy, accuracy);

        //Instatiate a new bullet from prefab "projectile"
        GameObject clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        //Get the component from the new bullet
        Bullet newBullet = clone.GetComponent<Bullet>();
        //Tell the ullet to Fire()
        newBullet.Fire(direction + spread);
    }
}
