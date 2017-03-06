using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondScoreText : MonoBehaviour 
{
    public Text ScoreText;

	void Update()
    {
        GetComponent<Text>().text = ScoreText.text;
	}
}
