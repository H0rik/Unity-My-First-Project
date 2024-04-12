using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform player;
    Vector3 corection=new Vector3(0,0,0);
    Vector3 direction= new Vector3(0, 0, 0);
    public float speed = 1f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        corection = transform.position - player.position;
    }

    
    void Update()
    {
        if (player!=null)
        {
            direction = player.position + corection - transform.position;
            transform.position += Time.deltaTime * speed * direction;
        }
    }
    
}
