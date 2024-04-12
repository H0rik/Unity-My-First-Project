using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpitter : MonoBehaviour
{
    GameObject player;
    GameObject spike;
    public Transform projectile;

    public float speed = 5f;
    public float distance;
    Rigidbody2D rb2D;

    float aim;
    Vector2 shootdir;   
    public bool aiming = false;
    bool ready = false;
    //public float distance;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2D = this.GetComponent<Rigidbody2D>();
        spike = transform.GetChild(2).gameObject;
        spike.SetActive(false);
    }


    private void FixedUpdate()
    {
        if(player != null) 
        {
            Vector3 direction = player.transform.position - transform.position;
            distance = direction.magnitude;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if ((direction.magnitude < 10f) && (aiming == false))
            {
                aiming = true;
                aim = Time.time;

            }

            if ((aiming == true) && (Time.time - aim > 2f) && (ready == false))
            {
                spike.SetActive(true);
                shootdir = direction;
                ready = true;

            }
            if ((ready == true) && (Time.time - aim > 3f))
            {
                Transform projectileLunched = Instantiate(projectile, transform.position, transform.rotation); //Quaternion.identity);        
                projectileLunched.GetComponent<Projectile>().Setup(shootdir);
                spike.SetActive(false);
                ready = false;
                aiming = false;


            }
            if (direction.magnitude < 10f)
            {
                direction.x = 0;
                direction.y = 0;
            }
            if (!ready)
            {
                rb2D.rotation = angle;
            }
            rb2D.velocity = direction.normalized * speed;
        }
    }
}    
