using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Transform projectile;
    public GameObject flagPrefab;
    public GameObject flag=null;
    //Transform louncher;
    Rigidbody2D rb2D;
    public bool gun = false;
    public bool run = false;
    public float moveSpeed;
    Vector2 moveDir=new Vector2(0,0);
    


    private void Awake()
    {
        //louncher = transform.GetChild(0);
        rb2D= GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.touchCount > 1)
        {
            Touch touch = Input.GetTouch(1);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase == TouchPhase.Began)
            {
                if (gun)
                {
                    Transform projectileLunched = Instantiate(projectile, transform.position, Quaternion.identity);
                    Vector2 transform2D =new Vector2(transform.position.x, transform.position.y);
                    Vector2 shoodir = (worldPosition - transform2D).normalized;
                    projectileLunched.GetComponent<Projectile>().Setup(shoodir);                    
                }
                if (run)
                {
                    SetFlag(worldPosition);
                }
            }
        }
    }
    
    private void FixedUpdate()
    {
        if(flag!=null)
        {            
            moveDir = flag.transform.position - transform.position;           
            if(moveDir.magnitude < 0.5f)
            {
                Destroy(flag);
                moveDir.x = 0f;
                moveDir.y = 0f;
            }
        }
        rb2D.velocity = moveDir.normalized * moveSpeed;
    }
    void SetFlag(Vector2 position)
    {
        //Transform projectileLunched = Instantiate(projectile, transform.position, Quaternion.identity);
        if (flag == null)
        {
            flag=Instantiate(flagPrefab,position,Quaternion.identity);
        } else
        {
            flag.transform.position = position;
        }        
    }
    public void WillGun()
    {
        gun = true;
    }
    public void NoGun()
    {
        gun = false;
    }
    public void WillRun()
    {
        run= true;
    }
    public void NoRun()
    {
        run = false;
    }
    


}
