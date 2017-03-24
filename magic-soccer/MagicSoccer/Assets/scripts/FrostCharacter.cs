using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FrostCharacter : MonoBehaviour 
{
    public AudioClip[] audioClips;
    public GameObject[] bulletsPrefabs;
    public float[] delays;
    public float speed, boundary;
    public int wallsDistanceFromAPlayer;
    AudioSource audioSource;
    CooldownHandler cooldownHandler;
    Player player;
    Transform bulletsTransform;
    GameObject ball;
    int[] buttonsValues;
    float[] cooldowns;
    bool doesAHumanPlay, canShootASuperBullet;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cooldowns = new float[3];
        player = transform.parent.GetComponent<Player>();
        cooldownHandler = player.cooldownHandler;
        bulletsTransform = GameObject.Find("bullets").transform;
        ball = GameObject.Find("ball");
        doesAHumanPlay = player.GetDoesAHumanPlay();
        canShootASuperBullet = false;
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
        GetComponent<AudioSource>().volume = player.GetSoundsVolume();

        if(doesAHumanPlay)
        {
            buttonsValues = player.GetButtonsValues();

            Shoot();
        }
        else
        {
            BotShoot();
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

    void FixedUpdate()
    {
        if(doesAHumanPlay)
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
        for (int i = 1; i < buttonsValues.Length - 1; i++)
        {
            int j = i - 1;
            if (buttonsValues[i] == 1 && cooldowns[j] <= 0)
            {
                Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[j].transform.position.y, transform.position.z);
                Instantiate(bulletsPrefabs[j], pos, bulletsPrefabs[j].transform.rotation, bulletsTransform);
                cooldowns[j] = delays[j];
                audioSource.clip = audioClips[j];
                audioSource.Play();
            }
        }

        if (buttonsValues[3] == 1 && cooldowns[2] <= 0 && !canShootASuperBullet)
        {
            float posX = 0;

            if (transform.position.x > 0)
            {
                posX = transform.position.x - wallsDistanceFromAPlayer;
            }
            else
            {
                posX = transform.position.x + wallsDistanceFromAPlayer;
            }

            Vector3 pos = new Vector3(posX, bulletsPrefabs[2].transform.position.y, transform.position.z);
            GameObject wall = Instantiate(bulletsPrefabs[2], pos, bulletsPrefabs[2].transform.rotation, bulletsTransform) as GameObject;
            wall.GetComponent<FrostWall>().SetWhoCreated(this);
            cooldowns[2] = delays[2];
            audioSource.clip = audioClips[2];
            audioSource.Play();
        }
        else if (buttonsValues[3] == 1 && cooldowns[2] <= 0 && canShootASuperBullet)
        {
            Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[3].transform.position.y, transform.position.z);
            Instantiate(bulletsPrefabs[3], pos, bulletsPrefabs[3].transform.rotation, bulletsTransform);
            cooldowns[2] = delays[3];
            audioSource.clip = audioClips[3];
            audioSource.Play();
            canShootASuperBullet = false;
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
        if (cooldowns[0] <= 0 && Math.Abs(ball.transform.position.x - transform.position.x) < 11)
        {
            Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[0].transform.position.y, transform.position.z);
            Instantiate(bulletsPrefabs[0], pos, bulletsPrefabs[0].transform.rotation, bulletsTransform);
            cooldowns[0] = delays[0];
        }

        if(cooldowns[1] <= 0)
        {
            Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[1].transform.position.y, transform.position.z);
            Instantiate(bulletsPrefabs[1], pos, bulletsPrefabs[1].transform.rotation, bulletsTransform);
            cooldowns[1] = delays[1];
        }

        if (cooldowns[2] <= 0 && !canShootASuperBullet && Math.Abs(ball.transform.position.x - transform.position.x) < 5)
        {
            float posX = 0;

            if (transform.position.x > 0)
            {
                posX = transform.position.x - wallsDistanceFromAPlayer;
            }
            else
            {
                posX = transform.position.x + wallsDistanceFromAPlayer;
            }

            Vector3 pos = new Vector3(posX, bulletsPrefabs[2].transform.position.y, transform.position.z);
            GameObject wall = Instantiate(bulletsPrefabs[2], pos, bulletsPrefabs[2].transform.rotation, bulletsTransform) as GameObject;
            wall.GetComponent<FrostWall>().SetWhoCreated(this);
            cooldowns[2] = delays[2];
            audioSource.clip = audioClips[2];
            audioSource.Play();
        }
        else if (buttonsValues[3] == 1 && cooldowns[2] <= 0 && canShootASuperBullet)
        {
            Vector3 pos = new Vector3(transform.position.x, bulletsPrefabs[3].transform.position.y, transform.position.z);
            Instantiate(bulletsPrefabs[3], pos, bulletsPrefabs[3].transform.rotation, bulletsTransform);
            cooldowns[2] = delays[3];
            audioSource.clip = audioClips[3];
            audioSource.Play();
            canShootASuperBullet = false;
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

    public void SetCanShootASuperBullet()
    {
        canShootASuperBullet = true;
        cooldowns[2] = 0;
    }
}