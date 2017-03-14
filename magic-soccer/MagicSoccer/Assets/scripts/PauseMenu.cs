using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
    public GameSet gameSet;
    public Scrollbar musicScrollbar, soundsScrollbar;
    public GameObject colorChangeButton;
    int colorMode; //0 for green field, 1 for field changing colors
    bool isPaused;
    float time;

    void Start()
    {
        isPaused = false;
        colorMode = 0;
        time = 0;

        if (GameObject.FindWithTag("NotToDestroy-PauseMenu"))
        {
            Destroy(gameObject);
        }
        else
        {
            tag = "NotToDestroy-PauseMenu";
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Pause();
        }

        if(isPaused)
        {
            gameSet.SetMusicVolume(musicScrollbar.value);
            gameSet.SetSoundsVolume(soundsScrollbar.value);
        }

        if (colorMode == 0)
        {
            colorChangeButton.GetComponent<Image>().color = Color.green;
        }
        else if (colorMode == 1)
        {
            time += Time.deltaTime;

            if (time >= 0.2f)
            {
                colorChangeButton.GetComponent<Image>().color = new Color(Random.Range(0.7f, 1f), Random.Range(0.7f, 1f), Random.Range(0.7f, 1f), 1f);
                time = 0;
            }
        }
    }

    public void Pause()
    {
        isPaused = !isPaused;
        transform.GetChild(0).gameObject.SetActive(isPaused);
    }

    public void ChangeColors(GameObject go)
    {
        colorMode++; 
        colorMode %= 2;
        gameSet.SetGrassColorMode(colorMode);

        if(colorMode == 0)
        {
            go.transform.GetChild(0).GetComponent<Text>().text = "green";
        }
        else if(colorMode == 1)
        {
            go.transform.GetChild(0).GetComponent<Text>().text = "illuminating";
        }
    }
}
