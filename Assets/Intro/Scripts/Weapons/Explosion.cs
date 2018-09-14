using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Projectiles
{
    public float explosionRadius = 5f;
    public GameObject explosion;

	public override void OnCollisionEnter(Collision col)
    {
        string tag = col.collider.tag;
        if (tag != "Player" && tag != "Weapon")
        {
            print(col.collider.tag);
            Effects();      // Spawns a particle
            Explode();      // Deals damage to surrounding enemies
        }
        
    }

    void Effects()
    {
        //Spawn a new explosion GameObject
        Instantiate(explosion, transform.position, transform.rotation);
    }

   void Explode()
    {
        // Detect collision with objects using radius
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius)
        
        //loop through everything we hit
        foreach (var hit in hits)
        {
            // try getting the enemy component
            Enemy e = hit.GetComponent<Enemy>();
            //If we hit an enemy
            if (e)
            {
                //note: you can calculate a falloff damage here

                //Deal damage to the enemy
                e.DealDamage(damage);

            }

        }
            
            
    }

}
