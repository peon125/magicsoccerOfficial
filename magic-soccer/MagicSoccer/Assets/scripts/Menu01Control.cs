using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu01Control : MonoBehaviour 
{   
    public Image[] buttons;
    GameSet gameSet;

    void Start()
    {
        gameSet = GameObject.Find("gameSet").GetComponent<GameSet>();
    }

    public void SetWhetherAPlayerIsPlaying(int player)
    {
        gameSet.SetWhetherAPlayerIsPlaying(player);

        if (gameSet.playingPlayers[player])
        {
            buttons[player].color = Color.green;
        }
        else if (!gameSet.playingPlayers[player])
        {
            buttons[player].color = Color.red;
        }
    }

    public void GoToTheNextStage()
    {
        SceneManager.LoadScene("menu02");
    }
}
