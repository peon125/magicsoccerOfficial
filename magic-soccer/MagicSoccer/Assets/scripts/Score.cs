using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour 
{
    public MatchControl gameController;
    public int player;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "ball")
        {
            gameController.IncrementScore(player);
        }
    }
}
