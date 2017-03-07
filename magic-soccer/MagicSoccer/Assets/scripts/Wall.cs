using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour 
{
    int durability; 

	void Start () 
    {
        durability = 3;
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "ball")
        {
            durability--;

            switch (durability)
            {
                case 2:
                    GetComponent<MeshRenderer>().material.color = new Color(1, 0.5f, 0);
                    break;
                case 1:
                    GetComponent<MeshRenderer>().material.color = Color.red;
                    break;
                case 0:
                    gameObject.SetActive(false);
                    break;
            }
        }
    }

    public void BringBackToLife()
    {
        gameObject.SetActive(true);
        GetComponent<Renderer>().material.color = Color.yellow;
        durability = 3;
    }
}
