using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu01Control : MonoBehaviour 
{   
    public Camera sceneCamera;
    public Color[] colors;
    public Image[] buttons;
    GameSet gameSet;

    void Start()
    {
        Color randomColor = colors[Random.Range(0, colors.Length)];
        sceneCamera.backgroundColor = randomColor;

        gameSet = GameObject.Find("gameSet").GetComponent<GameSet>();

        gameSet.SetWhetherAPlayerIsPlaying(0, false); //in case someone came back to the this scene from other scene
        gameSet.SetWhetherAPlayerIsPlaying(1, false);
        gameSet.SetBackgroundColor(randomColor);
    }

    public void SetWhetherAPlayerIsPlaying(int player)
    {
        bool b = gameSet.playingPlayers[player];

        gameSet.SetWhetherAPlayerIsPlaying(player, !b);

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
