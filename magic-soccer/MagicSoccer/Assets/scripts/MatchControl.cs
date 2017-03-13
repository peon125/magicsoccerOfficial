using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchControl : MonoBehaviour 
{
    public Text scoreText;
    public Player player1, player2;
    public GameObject ball, p1Wall, p2Wall;
    public Transform bulletsTransform;
    int p1Score, p2Score;

	void Start()
    {
        p1Score = 0;
        p2Score = 0;
	}

    public void IncrementScore(int player)
    {
        if (player == 1)
        {
            p1Score++;
        }
        else if (player == 2)
        {
            p2Score++;
        }

        scoreText.text = p1Score + " - " + p2Score;

        ball.GetComponent<Ball>().ResetPosition();

        p1Wall.GetComponent<Wall>().BringBackToLife();
        p2Wall.GetComponent<Wall>().BringBackToLife();

        player1.SetDoResetCooldowns(true);
        player2.SetDoResetCooldowns(true);

        foreach(Transform t in bulletsTransform)
        {
            Destroy(t.gameObject);
        }
    }
}
