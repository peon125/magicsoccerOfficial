using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EndBoard : MonoBehaviour 
{
    public GameObject ground, ball;
    public Text whoWon, totalTime;
    float time;

    void Start()
    {
        time = 0;
    }

	void Update() 
    {
        time += Time.deltaTime;

        if (time >= 0.2)
        {
            ground.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            time = 0;
        }
	}

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

        ball.SetActive(false);
    }
}