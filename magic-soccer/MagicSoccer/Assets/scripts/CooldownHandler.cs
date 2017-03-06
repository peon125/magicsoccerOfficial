using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CooldownHandler : MonoBehaviour 
{
    public Text[] cooldownsTexts;
    float[] cooldowns;

	void Start() 
    {
        cooldowns = new float[0];
	}
	
	void Update() 
    {
        try{
            for (int i = 0; i < cooldownsTexts.Length; i++) 
            {
                if(cooldowns[i] <= 0)
                {
                    cooldownsTexts[i].text = "0.0";
                    cooldownsTexts[i].transform.parent.GetComponent<Image>().color = Color.green;
                } else
                {
                    string text = cooldowns[i].ToString();
                    cooldownsTexts[i].text = text.Substring(0, text.IndexOf(".") + 2);
                    cooldownsTexts[i].transform.parent.GetComponent<Image>().color = Color.red;
                }
            }
        } catch (Exception)
        {
            Debug.Log("I haven't received a cooldown table yet");
        }
    }

    public void setCooldowns(float[] f)
    {
        cooldowns = f;
    }
}