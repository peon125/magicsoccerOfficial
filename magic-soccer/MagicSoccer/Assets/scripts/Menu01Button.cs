using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu01Button : MonoBehaviour 
{
    GameSet gameSet;

    void Start()
    {
        gameSet = GameObject.Find("gameSet").GetComponent<GameSet>();
    }

    public void SetWhetherAPlayerIsPlaying(int player) //0 for Player 1, 1 for Player 2
    {
        gameSet.SetWhetherAPlayerIsPlaying(player);

        if (gameSet.playingPlayers[player])
        {
            GetComponent<Image>().color = Color.green;
        }
        else if (!gameSet.playingPlayers[player])
        {
            GetComponent<Image>().color = Color.red;
        }
    }

    public void GoToTheNextStage()
    {
        SceneManager.LoadScene("menu02");
    }
}