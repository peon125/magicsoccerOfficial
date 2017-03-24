using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioClip[] tracks;
    public GameSet gameSet;
    string sceneName;

	void Start()
    {
        if (GameObject.FindWithTag("NotToDestroy-MusicController"))
        {
            Destroy(gameObject);
        }
        else
        {
            tag = "NotToDestroy-MusicController";
        }

        DontDestroyOnLoad(gameObject);
        sceneName = "";
	}

	void Update()
    {
        if(SceneManager.GetActiveScene().name != sceneName)
        {
            if(SceneManager.GetActiveScene().name.Contains("menu") && !sceneName.Contains("menu"))
            {
                GetComponent<AudioSource>().clip = tracks[0];
                GetComponent<AudioSource>().Play();
            }
            else if(SceneManager.GetActiveScene().name == "match")
            {

                GetComponent<AudioSource>().clip = tracks[Random.Range(1, tracks.Length)];
                GetComponent<AudioSource>().Play();
            }
        }

        sceneName = SceneManager.GetActiveScene().name;

        GetComponent<AudioSource>().volume = gameSet.GetMusicVolume();
	}
}
