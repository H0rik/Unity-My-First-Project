using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int strikes = 0;
    public int hp= 5;
    GameObject gameOver;
    GameObject respawn;
    GameObject gameMenu;
    Text health;
    HealthUI healthSprite;


    private void Awake()
    {
        gameOver = GameObject.FindGameObjectWithTag("GameOver");
        gameOver.SetActive(false);
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        gameMenu = GameObject.FindGameObjectWithTag("GameMenu");
        health = GameObject.FindGameObjectWithTag("Energy").GetComponent<Text>();
        health.text = "Energy: " + hp.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            strikes++;
            hp--;
            Vector3 hit = transform.position - collision.transform.position;
            collision.gameObject.transform.position += -hit * 2f;
            collision.gameObject.GetComponent<Enemy>().DidBite();
        }
        if (collision.collider.CompareTag("Spike"))
        {
            Vector3 hit = transform.position - collision.transform.position;
            collision.gameObject.transform.position += -hit * 1.5f;
            Destroy(collision.gameObject);
            hp--;
        }
        if (collision.collider.CompareTag("Pick-Up"))
        {
            hp++;
            Destroy(collision.gameObject);
        }
        if (hp <= 0)
        {
            GameOver();
        }
        health.text = "Energy: " + hp.ToString();
        healthSprite.ChangeHealth(hp);
    }
        
    void GameOver()
    {   
        gameOver.GetComponent<RestartButton>().gameMenu= gameMenu;
        gameOver.GetComponent<RestartButton>().player = this.gameObject;
        gameOver.GetComponent<RestartButton>().respawn= respawn;
        gameOver.GetComponent<RestartButton>().health = healthSprite;



        gameOver.SetActive(true);
        gameMenu.SetActive(false);
        gameObject.SetActive(false);
    }
        
    public void SetHealthUI(HealthUI health)
    {
        healthSprite = health;
    }


}
