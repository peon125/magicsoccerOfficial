using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : MonoBehaviour 
{
    public GameObject[] characters, selectedCharacters;
    public bool[] playingPlayers;
    Color backgroundColor;
    float musicVolume, soundsVolume;
    int grassColorMode;

	void Start() 
    {
        if (GameObject.FindWithTag("NotToDestroy-GameSet"))
        {
            Destroy(gameObject);
        }
        else
        {
            tag = "NotToDestroy-GameSet";
        }

        musicVolume = 1f;
        soundsVolume = 1f;
        grassColorMode = 0;

        if(backgroundColor == null)
        {
            backgroundColor = new Color(1, 1, 0.50588f);
        }

        DontDestroyOnLoad(gameObject);
	}

    public void SetWhetherAPlayerIsPlaying(int player, bool b)
    {
        playingPlayers[player] = b;
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

    public Color GetBackgroundColor()
    {
        return backgroundColor;
    }

    public void SetBackgroundColor(Color c)
    {
        backgroundColor = c;
    }
}