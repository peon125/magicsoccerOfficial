using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWall : MonoBehaviour 
{
    public float lifeTime;
    FrostCharacter whoCreated;

	void Start()
    {
        Destroy(gameObject, lifeTime);
    }
	
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "ball")
        {
            collider.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
            whoCreated.SetCanShootASuperBullet();
            Destroy(gameObject, 0.25f);
        }
    }

    public void SetWhoCreated(FrostCharacter frostCharacter)
    {
        whoCreated = frostCharacter;
    }
}
