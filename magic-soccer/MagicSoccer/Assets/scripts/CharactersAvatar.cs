using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersAvatar : MonoBehaviour 
{
    public GameObject borderPrefab;
    Menu02Control gameController;
    GameSet gameSet;
    int player, index;

	void Start()
    {
        gameController = GameObject.Find("gameController").GetComponent<Menu02Control>();
        gameSet = GameObject.Find("gameSet").GetComponent<GameSet>();
	}

    public void Choose()
    {
        if(gameSet.playingPlayers[player])
        {
            Destroy(GameObject.Find("border" + player));
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            GameObject border = Instantiate(borderPrefab, pos, new Quaternion(0, 0, 0, 0), transform);
            border.name = "border" + player;

            gameSet.SetAPlayersSelectedCharacter(player, index);
            gameController.SetDisplayedPicsAndDescs(player, index);
        }
    }

    public void SetIndex(int i)
    {
        index = i;
    }

    public void SetPlayer(int i)
    {
        player = i;
    }
}
