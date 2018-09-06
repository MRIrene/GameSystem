using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Practice
{
    public class Bullet : MonoBehaviour
    {

        public int damage = 50;
        public float speed = 5f;
        public Rigidbody rigid;

        // Method for 'Firing' the bullet using Rigidbody
        public void Fire(Vector3 direction)
        {
            //Add a force in the given 'direction' variable and use impluse
            rigid.AddForce(direction * speed, ForceMode.Impulse);
        }

        // when the bullet hits an object this function is called
        private void OnTriggerEnter(Collider other)
        {
            //Get the Enemy component from it
            Enemy enemy = other.GetComponent<Enemy>();
            //If it is indeed an Enemy
            if (enemy)
            {
                //Deal damage to the Enemy
                //enemy.DealDamage(damage);
                //Destory the bullet
                Destroy(gameObject);
            }
        }

    }
}