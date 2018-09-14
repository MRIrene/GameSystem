using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

    public float speed = 5f;
    public int damage = 100;
    public float range = 50f;

    public GameObject impact;
    public Rigidbody rigid;

	public  virtual void Fire(Vector3 direction)
    {
        //shoot the bullet off in given direction x speed
        rigid.AddForce(direction * speed, ForceMode.Impulse);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {

    }
}
