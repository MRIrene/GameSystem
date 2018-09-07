using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {


    //public GameObject bullet;
    //public Transform spawnPoint;
    //public KeyCode firebutton;
	
	// Update is called once per frame
	public override void Attack()
    { 
            //Instatiate a new bullet from prefab "projectile"
            GameObject clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            //Get the component from the new bullet
            Bullet newBullet = clone.GetComponent<Bullet>();
            //Tell the ullet to Fire()
            newBullet.Fire(transform.forward);
        
	}
}
