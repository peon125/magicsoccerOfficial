using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour 
{
    float time;
    GameSet gameSet;
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
            GetComponent<MeshRenderer>().material.color = Color.green;
        } 
        else if(mode == 1)
        {
            time += Time.deltaTime;

            if (time >= 0.2f)
            {
                GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                time = 0;
            }
        }
	}
}
