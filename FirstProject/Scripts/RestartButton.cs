using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject player;
    GameObject gameOver;
    public GameObject gameMenu;
    public HealthUI health;
    public GameObject respawn;
    private void Start()
    {
        gameOver = this.gameObject;        
    }
    public void RestartPress ()
    {
        GameObject[] bug = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < bug.Length; i++) Destroy(bug[i]);

        respawn.GetComponent<SpawnCenter>().StartButton(player.transform);
        player.SetActive(true);
        player.GetComponent<PlayerHealth>().hp = 5;
        health.RestartGame(5);
        gameOver.SetActive(false);
        gameMenu.SetActive(true);
        //respawn.SetActive(true);
                
    }
}
