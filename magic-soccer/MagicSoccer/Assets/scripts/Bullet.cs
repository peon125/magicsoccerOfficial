using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour 
{
    public float speed;
    public float momentum;
    public int whatKindOfShot;

	void Start() 
    {
        if(transform.position.x > 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            speed = -speed;
        }

        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = new Vector3(speed, 0, 0);
        r.mass = Math.Abs(momentum / speed);
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "ball")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if ((collider.name == "half" && whatKindOfShot == 0) || (collider.name == "wholeField" && whatKindOfShot == 1))
        {
            Destroy(gameObject);
        }
        else if (collider.name == "wholeField" && whatKindOfShot == 1)
        {
            Destroy(gameObject);
        }
    }
}