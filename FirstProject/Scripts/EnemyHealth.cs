using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Score score;
    public int enemyHP;
    public Transform deadEnemy;
    public Transform pickUpHealth;
    public int pickUpChance;
    int chance;
    private void Awake()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);           
            enemyHP--;
            if (enemyHP <= 0)
            {
                score.IncreaseScore();
                Destroy(gameObject);
                if (Random.Range(1, pickUpChance) == 1)
                    Instantiate(pickUpHealth, transform.position, Quaternion.identity);
                else
                    Instantiate(deadEnemy, transform.position, Quaternion.identity);
            }
        }
    }    
}