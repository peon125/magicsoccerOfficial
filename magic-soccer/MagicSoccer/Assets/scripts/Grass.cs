using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour 
{
    public GameObject ball;
    GameSet gameSet;
    float time;
    int mode;

    void Start()
    {
        gameSet = GameObject.Find("gameSet").GetComponent<GameSet>();
        time = 0;
    }

	void Update() 
    {
        mode = gameSet.GetGrassColorMode();

        if(mode == 0)
        {
            GetComponent<MeshRenderer>().material.color = new Color(38 / 255, 1, 38 / 255);
            ball.GetComponent<MeshRenderer>().material.color = Color.white;
        } 
        else if(mode == 1)
        {
            time += Time.deltaTime;

            if (time >= 0.2f)
            {
                Color color = new Color(Random.Range(0.5f, 0.9f), Random.Range(0.5f,  0.9f), Random.Range(0.5f,  0.9f));
                GetComponent<MeshRenderer>().material.color = color;
                ball.GetComponent<MeshRenderer>().material.color = new Color(1 - color.r, 1 - color.g, 1 - color.b);
                time = 0;
            }
        }
	}
}
