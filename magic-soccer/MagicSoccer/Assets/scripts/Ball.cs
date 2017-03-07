﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
    public float maxPositionZ;

	void Start() 
    {
        ResetPosition();
	}

    public void ResetPosition()
    {
        float randomZ = Random.Range(-maxPositionZ, maxPositionZ);
        transform.position = new Vector3(0, gameObject.transform.position.y, randomZ);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}