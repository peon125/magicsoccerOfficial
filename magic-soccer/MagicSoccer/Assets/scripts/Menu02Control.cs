using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu02Control : MonoBehaviour 
{
    public Camera sceneCamera;
    public Transform[] listsTranforms;
    public Image[] p1SkillsPics;
    public Image[] p2SkillsPics;
    public Text[] p1SkillsDescs;
    public Text[] p2SkillsDescs;
    public GameObject avatarPrefab;
    public float distance;
    GameSet gameSet;
    Image[,] skillsPics;
    Text[,] skillsDescs;

    void Start()
    {
        gameSet = GameObject.Find("gameSet").GetComponent<GameSet>();

        sceneCamera.backgroundColor = gameSet.GetBackgroundColor();

        skillsPics = new Image[gameSet.characters.Length, p1SkillsPics.Length];
        skillsDescs = new Text[gameSet.characters.Length, p1SkillsDescs.Length];

        for (int i = 0; i < p1SkillsPics.Length; i++)
        {
            skillsPics[0, i] = p1SkillsPics[i];
            skillsPics[1, i] = p2SkillsPics[i];
        }

        for (int i = 0; i < p1SkillsDescs.Length; i++)
        {
            skillsDescs[0, i] = p1SkillsDescs[i];
            skillsDescs[1, i] = p2SkillsDescs[i];
        }

        for (int i = 0; i < listsTranforms.Length; i++)
        {
            for (int j = 0; j < gameSet.characters.Length; j++) 
            {
                avatarPrefab.GetComponent<Image>().sprite = gameSet.characters[j].GetComponent<PicsAndDescs>().pictures[0];
                Vector2 pos = new Vector2(listsTranforms[i].position.x, listsTranforms[i].position.y);
                GameObject av = Instantiate(avatarPrefab, pos, new Quaternion(0, 0, 0, 0), listsTranforms[i]);
                av.GetComponent<RectTransform>().localPosition+= new Vector3(j * 200, 0, 0);
                av.name = i + "avatar" + j;
                av.GetComponent<CharactersAvatar>().SetIndex(j);
                av.GetComponent<CharactersAvatar>().SetPlayer(i);
            }
        }
    }

    public void SetDisplayedPicsAndDescs(int player, int index)
    {
        Sprite[] selectedPics = gameSet.characters[index].GetComponent<PicsAndDescs>().pictures;
        string[] selectedDescs = gameSet.characters[index].GetComponent<PicsAndDescs>().descriptions;

        for (int i = 0; i < selectedPics.Length-1; i++)
        {
            skillsPics[player, i].sprite = selectedPics[i];
        }

        for (int i = 0; i < selectedDescs.Length; i++)
        {
            skillsDescs[player, i].text = selectedDescs[i];
        }
    }

    public void LetsStartTheMatch()
    {
        SceneManager.LoadScene("match");
    }
}