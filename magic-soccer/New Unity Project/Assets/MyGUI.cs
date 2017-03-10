using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGUI : MonoBehaviour {

    public Image img1;
    public Image img2;
    public Image img3;
    public Image img4;


    void OnGUI()
    {
        Rect button1 = new Rect(0, 50, 150, 150);
        Rect button2 = new Rect(200, 50, 150, 150);
        Rect button3 = new Rect(400, 50, 150, 150);
        Rect button4 = new Rect(600, 50, 150, 150);

        GUI.RepeatButton(button1, "ni");
        GUI.RepeatButton(button2, "ni");
        GUI.RepeatButton(button3, "ni");
        GUI.RepeatButton(button4, "ni");


        foreach(Touch t in Input.touches)
        {
            if(button1.Contains(t.position))
            {
                img1.color = Color.red;
            }
            else {
                img1.color = Color.green;
            }

            if(button2.Contains(t.position))
            {
                img2.color = Color.red;
            }
            else {
                img2.color = Color.green;
            }

            if(button3.Contains(t.position))
            {
                img3.color = Color.red;
            }
            else {
                img3.color = Color.green;
            }
            if(button4.Contains(t.position))
            {
                img4.color = Color.red;
            }
            else {
                img4.color = Color.green;
            }

        }

    }
}
