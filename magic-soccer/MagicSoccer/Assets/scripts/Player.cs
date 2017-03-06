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
    bool doesAHumanPlay;
    bool doResetCooldowns;

	void Start() 
    {
        doesAHumanPlay = true;
        gameSet = GameObject.Find("gameSet").GetComponent<GameSet>();
        buttonsValues = new int[4];

        for (int i = 0; i < buttonsValues.Length; i++)
        {
            buttonsValues[i] = 0;
        }

        Vector3 pos = new Vector3(startingPositionX, 1, startingPositionZ);

        Instantiate(gameSet.selectedCharacters[whichPlayer], pos, new Quaternion(0, 180 * (whichPlayer - 1), 0, 0), transform);

        doesAHumanPlay = gameSet.playingPlayers[whichPlayer];
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

    public void SetDoResetCooldowns()
    {
        doResetCooldowns = true;
    }
}
