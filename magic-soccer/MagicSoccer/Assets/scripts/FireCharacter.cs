using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCharacter : MonoBehaviour 
{
    public AudioClip[] audioClips;
    public GameObject[] bulletsPrefabs;
    public float[] delays;
    public float speed, boundary;
    AudioSource audioSource;
    CooldownHandler cooldownHandler;
    Player player;
    Transform bulletsTransform;
    GameObject ball;
    int[] buttonsValues;
    float[] cooldowns;
    bool doesAHumanPlay;

	void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
                delays[i] *= 1.3f;
            }

            speed /= 1.3f;
        }
	}
	
	void Update()
    {
        GetComponent<AudioSource>().volume = player.GetSoundsVolume();

        if (doesAHumanPlay)
        {
            buttonsValues = player.GetButtonsValues();

            Shoot();
        }
        else
        {
            BotShoot();
        }

        if (player.GetDoResetCooldowns())
        {
            ResetCooldowns();
        }

        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] -= Time.deltaTime;
        }

        cooldownHandler.setCooldowns(cooldowns);
    }

    void FixedUpdate()
    {
        if (doesAHumanPlay)
        {
            Move();
        }
        else
        {
            BotMove();
        }
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
            if (buttonsValues[i] == 1 && cooldowns[j] <= 0)
            {
                Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[j].transform.position.y, transform.position.z);
                Instantiate(bulletsPrefabs[j], pos, bulletsPrefabs[j].transform.rotation, bulletsTransform);
                cooldowns[j] = delays[j];
                audioSource.clip = audioClips[i - 1];
                audioSource.Play();
            }
        }
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
                if ((i < 2 && Mathf.Abs(ball.transform.position.x - transform.position.x) < 11) || i == 2)
                {
                    Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[i].transform.position.y, transform.position.z);
                    Instantiate(bulletsPrefabs[i], pos, bulletsPrefabs[i].transform.rotation, bulletsTransform);
                    cooldowns[i] = delays[i];
                    audioSource.clip = audioClips[i];
                    audioSource.Play();
                }
            }
        }
    }

    void ResetCooldowns()
    {
        for (int i = 0; i < cooldowns.Length; i++)
        {
            cooldowns[i] = 0;
            buttonsValues[i] = 0;
        }

        player.SetDoResetCooldowns(false);
    }
}
