using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed= 15f;
     Vector3 shootdir;
    public void Setup(Vector3 shootdir)
    {
        this.shootdir = shootdir;
        Destroy(gameObject, 3f);
    }
   
    void Update()
    {
        transform.position += Time.deltaTime * speed*shootdir;
    }
}
