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
    public EndBoard endBoard;
    int p1Score, p2Score;
    float time;

	void Start()
    {
        p1Score = 0;
        p2Score = 0;
        time = 0;
	}

    void Update()
    {
        time += Time.deltaTime;
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

        if((p1Score >= 3 || p2Score >= 3) && (p1Score > p2Score + 1 || p2Score > p1Score + 1))
        {
            endBoard.gameObject.SetActive(true);
            endBoard.EndGame(p1Score, p2Score, (int)time);
            return;
        }

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
