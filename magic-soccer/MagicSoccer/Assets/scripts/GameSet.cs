using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : MonoBehaviour 
{
    public GameObject[] characters, selectedCharacters;
    public bool[] playingPlayers;
    float musicVolume, soundsVolume;
    int grassColorMode;

	void Start() 
    {
        grassColorMode = 0;

        if (GameObject.FindWithTag("NotToDestroy-GameSet"))
        {
            Destroy(gameObject);
        }
        else
        {
            tag = "NotToDestroy-GameSet";
        }

        DontDestroyOnLoad(gameObject);
	}

    public void SetWhetherAPlayerIsPlaying(int player)
    {
        playingPlayers[player] = !playingPlayers[player];
    }

    public void SetAPlayersSelectedCharacter(int player, int index)
    {
        selectedCharacters[player] = characters[index];
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public void SetMusicVolume(float f)
    {
        musicVolume = f;
    }

    public float GetSoundsVolume()
    {
        return soundsVolume;
    }

    public void SetSoundsVolume(float f)
    {
        soundsVolume = f;
    }

    public int GetGrassColorMode()
    {
        return grassColorMode;
    }

    public void SetGrassColorMode(int i)
    {
        grassColorMode = i;
    }
}