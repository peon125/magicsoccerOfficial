using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndBoard : MonoBehaviour 
{
    public Text whoWon, totalTime;

    public void EndGame(int p1Score, int p2Score, int time)
    {
        totalTime.text = (time / 60).ToString() + " m " + (time % 60).ToString() + " s ";

        if(p1Score > p2Score)
        {
            whoWon.text = "Player 1 wins!";
        }
        else if(p2Score > p1Score)
        {
            whoWon.text = "Player 2 wins!";
        }

        foreach(GameObject button in GameObject.FindGameObjectsWithTag("uibutton"))
        {
            if (button.GetComponent<EventTrigger>())
            {
                button.GetComponent<EventTrigger>().enabled = false;
            }
        }

        Time.timeScale = 0;
    }

    public void GoHome()
    {
        SceneManager.LoadScene("menu01");
    }
}