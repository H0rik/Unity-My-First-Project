using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    GameObject player;
   
    GameObject gameMenu;
    GameObject respawn;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameMenu = GameObject.FindGameObjectWithTag("GameMenu");
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        player.SetActive(false);
        gameMenu.SetActive(false);
        respawn.SetActive(false);

    }
    public void StartPress()
    {
        player.SetActive(true);
        gameMenu.SetActive(true);
        respawn.SetActive(true);
        
        respawn.GetComponent<SpawnCenter>().StartButton(player.transform);
        this.gameObject.SetActive(false);
    }

}
