using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
    public float maxPositionZ;
    public AudioClip hitSound;
    GameSet gameSet;

	void Start() 
    {
        ResetPosition();

        gameSet = GameObject.Find("gameSet").GetComponent<GameSet>();
	}

    void Update()
    {
        GetComponent<AudioSource>().volume = gameSet.GetSoundsVolume();
    }

    public void ResetPosition()
    {
        float randomZ = Random.Range(-maxPositionZ, maxPositionZ);
        transform.position = new Vector3(0, gameObject.transform.position.y, randomZ);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void OnCollisionEnter()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = hitSound;
        audioSource.Play();
    }
}