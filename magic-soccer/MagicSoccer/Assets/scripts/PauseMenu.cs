using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
    bool isPaused;

    void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Pause();
        }
    }

    public void Pause()
    {
        isPaused = !isPaused;
        transform.GetChild(0).gameObject.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0;
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("uibutton");
            foreach (GameObject go in buttons)
            {
                go.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            Time.timeScale = 1;
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("uibutton");
            foreach (GameObject go in buttons)
            {
                go.GetComponent<Button>().interactable = true;
            }
        }
    }
}
