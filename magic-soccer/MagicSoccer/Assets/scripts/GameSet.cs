﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSet : MonoBehaviour 
{
    public GameObject[] characters;
    public bool[] playingPlayers;
    public int[] selectedCharacters;

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

        DontDestroyOnLoad(gameObject);
	}

    public void SetWhetherAPlayerIsPlaying(int player)
    {
        playingPlayers[player] = !playingPlayers[player];
    }

    public GameObject GetAPlayersSelectedCharacter(int player)
    {
        return characters[selectedCharacters[player]];
    }

    public void SetAPlayersSelectedCharacter(int player, int index)
    {
        selectedCharacters[player] = index;
    }
}