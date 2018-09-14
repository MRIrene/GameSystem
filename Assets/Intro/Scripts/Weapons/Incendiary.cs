using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incendiary : Projectiles {

    public float dotDuration = 2f;

    public override void OnCollisionEnter(Collision col)
    {
        Enemy e = col.collider.GetComponent<Enemy>();
        if (e)
        {
            //Disable bullet effects
            //burn the enemy
            Burn(e);
        }
    }

    IEnumerator Burn(Enemy enemy)
    {
        yield return new WaitForSeconds(dotDuration);
        enemy.DealDamage(damage);
        //Start it again
        StartCoroutine(Burn(enemy));
    }

}   

