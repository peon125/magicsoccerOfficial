using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public float speed;
    public float force;
    public int whatKindOfShot;

	void Start() 
    {
        if(transform.position.x > 0)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            speed = -speed;
        }

        force *= 10;

        GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
	}

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.name == "ball")
        {
            Rigidbody r = GetComponent<Rigidbody>();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(force * r.velocity);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.name == "half" && whatKindOfShot == 0)
        {
            Destroy(gameObject);
        }
        else if (collider.name == "wholeField" && whatKindOfShot != 0)
        {
            Destroy(gameObject);
        }
    }
}