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
    CooldownHandler cooldownHandler;
    Player player;
    Transform bulletsTransform;
    GameObject ball;
    int[] buttonsValues;
    float[] cooldowns;
    bool doesAHumanPlay;

	void Start()
    {
        cooldowns = new float[3];
        player = transform.parent.GetComponent<Player>();
        cooldownHandler = player.cooldownHandler;
        bulletsTransform = GameObject.Find("bullets").transform;
        ball = GameObject.Find("ball");
        doesAHumanPlay = player.GetDoesAHumanPlay();
        buttonsValues = player.GetButtonsValues();

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

        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] -= Time.deltaTime;
        }

        cooldownHandler.setCooldowns(cooldowns);
	}

    void Move()
    {
        transform.position += new Vector3(0, 0, (float)(buttonsValues[0] * speed));
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -boundary, boundary));
    }

    void Shoot()
    {
        for (int i = 1; i < buttonsValues.Length; i++)
        {
            int j = i - 1;
            if(buttonsValues[i] == 1 && cooldowns [j] <=0)
            {
                Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[j].transform.position.y, transform.position.z);
                Instantiate(bulletsPrefabs[j], pos, bulletsPrefabs[j].transform.rotation, bulletsTransform);
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
        if (ball.transform.position.z > transform.position.z)
        {
            transform.position += new Vector3(0, 0, speed);
        }
        else if (ball.transform.position.z < transform.position.z)
        {
            transform.position -= new Vector3(0, 0, speed);
        }
    }

    void BotShoot()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            if (cooldowns[i] <= 0)
            {
                Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[i].transform.position.y, transform.position.z);
                GameObject bullet = Instantiate(bulletsPrefabs[i], pos, bulletsPrefabs[i].transform.rotation, bulletsTransform);
                bullet.GetComponent<MeshRenderer>().material.color = transform.GetChild(0).GetComponent<Renderer>().material.color;
                cooldowns[i] = delays[i];
                break;
            }
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
