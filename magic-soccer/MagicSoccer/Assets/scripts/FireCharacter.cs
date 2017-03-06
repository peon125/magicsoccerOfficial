using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCharacter : MonoBehaviour 
{
    public GameObject[] bulletsPrefabs;
    public Sprite[] pictures;
    public float[] delays;
    public string[] descriptions;
    public float speed, boundary;
    int[] buttonsValues;
    float[] cooldowns;
    Player player;
    Transform bulletsTransform;
    GameObject ball;
    bool doesAHumanPlay;

	void Start()
    {
        player = transform.parent.GetComponent<Player>();
        doesAHumanPlay = player.GetDoesAHumanPlay();
        buttonsValues = player.GetButtonsValues();
        cooldowns = new float[3];
        bulletsTransform = GameObject.Find("bullets").transform;
        ball = GameObject.Find("ball");

        if(!doesAHumanPlay)
        {
            for (int i = 0; i < delays.Length; i++)
            {
                delays[i] *= 1.2f;
            }
        }
	}
	
	void Update()
    {
        if(doesAHumanPlay)
        {
            buttonsValues = player.GetButtonsValues();

            Move();

            Shoot();
        }
        else{
            IAmABot();
        }

        if(player.GetDoResetCooldowns())
        {
            ResetCooldowns();
        }
	}

    void Move()
    {
        transform.position += new Vector3(0, 0, (float)(buttonsValues[0] * speed));
        transform.position = new Vector3(0, transform.position.y, Mathf.Clamp(transform.position.z, -boundary, boundary));
    }

    void Shoot()
    {
        for (int i = 1; i < buttonsValues.Length; i++)
        {
            int j = i - 1;
            if(buttonsValues[i] == 1 && cooldowns [j] <=0)
            {
                Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[j].transform.position.y, transform.position.z);
                GameObject bullet = Instantiate(bulletsPrefabs[j], pos, bulletsPrefabs[j].transform.rotation, bulletsTransform) as GameObject;
                bullet.GetComponent<MeshRenderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;
                cooldowns[j] = delays[j];
            }
        }
    }

    void IAmABot()
    {
        BotMove();

        BotShoot();
    }

    void BotMove()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            if(cooldowns[i] <= 0)
            {
                Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[i].transform.position.y, transform.position.z);
                GameObject bullet = Instantiate(bulletsPrefabs[i], pos, bulletsPrefabs[i].transform.rotation, bulletsTransform);
                bullet.GetComponent<MeshRenderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;
                cooldowns[i] = delays[i];
                break;
            }
        }
    }

    void BotShoot()
    {
        if (ball.transform.position.z > transform.position.z)
        {
            transform.position += new Vector3(0, 0, speed);
        }
        else if (ball.transform.position.z < transform.position.z)
        {
            transform.position -= new Vector3(0, 0, speed);
        }
    }

    void ResetCooldowns()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] = 0;
        }
    }
}
