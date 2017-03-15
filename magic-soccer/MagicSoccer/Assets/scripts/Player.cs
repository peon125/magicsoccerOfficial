using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
    public float startingPositionX, startingPositionZ;
    public CooldownHandler cooldownHandler;
    public int whichPlayer;
    int[] buttonsValues;
    GameSet gameSet;
    float soundsVolume;
    bool doResetCooldowns, doesAHumanPlay;

	void Start() 
    {
        buttonsValues = new int[4];
        doesAHumanPlay = true;
        gameSet = GameObject.Find("gameSet").GetComponent<GameSet>();

        for (int i = 0; i < buttonsValues.Length; i++)
        {
            buttonsValues[i] = 0;
        }

        GameObject characterToSpawn = gameSet.selectedCharacters[whichPlayer - 1];

        Vector3 pos = new Vector3(startingPositionX, characterToSpawn.transform.position.y, startingPositionZ);

        Instantiate(characterToSpawn, pos, new Quaternion(0, 180 * (whichPlayer - 1), 0, 0), transform);

        doesAHumanPlay = gameSet.playingPlayers[whichPlayer - 1];
	}

    void Update()
    {
        soundsVolume = gameSet.GetSoundsVolume();
    }

    public void SetButtonValueToOne(int i)
    {
        buttonsValues[i] = 1;
    }

    public void SetButtonValueToMinusOne(int i)
    {
        buttonsValues[i] = -1;
    }

    public void SetButtonValueToZero(int i)
    {
        buttonsValues[i] = 0;
    }

    public int[] GetButtonsValues()
    {
        return buttonsValues;
    }

    public bool GetDoesAHumanPlay()
    {
        return doesAHumanPlay;
    }

    public bool GetDoResetCooldowns()
    {
        return doResetCooldowns;
    }

    public void SetDoResetCooldowns(bool b)
    {
        doResetCooldowns = b;
    }

    public float GetSoundsVolume()
    {
        return soundsVolume;
    }
}
