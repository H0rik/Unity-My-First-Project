using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform player;
    public float speed = 5f;
    Rigidbody2D rb2D;
    bool isChewing = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isChewing)
        {
            if (player != null)
            {
                Vector3 direction = player.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb2D.rotation = angle;
                direction.Normalize();
                rb2D.velocity = direction.normalized * speed;
            }
        }else
        {
            rb2D.velocity= Vector3.zero;
        }
    }
    public void DidBite()
    {
        isChewing=true;
        StartCoroutine(Chewing());
    }

    IEnumerator Chewing()
    {
     
        yield return new WaitForSeconds(3f);
        isChewing = false;
    }

}
