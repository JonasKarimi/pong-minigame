using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] float speed =4f;
    [SerializeField] float  speed_multiplier=1f;
    [SerializeField] int max_speed =20;
    public float drag = 3f;
    private Rigidbody2D pRacket;
    private Camera camera;
    public KeyCode Up;
    public KeyCode Down;


    void Start()
    {
        pRacket = this.GetComponent <Rigidbody2D>();
        camera = Camera.main;
        pRacket.drag = drag;
        
    }

    void Update()
    {
        move();
        clamp();
    }

    void move()
    {
        Vector2 basespeed = new Vector2 (0f,0f);
        if(Input.GetKey(Up))
        {
            if(basespeed.y<max_speed)
                basespeed+= new Vector2(0f,speed*speed_multiplier);
            pRacket.velocity = basespeed; 
            FindObjectOfType<Ball>().Inheritspeed(basespeed.y);
        }

        if(Input.GetKey(Down))
        {
            if(basespeed.y>-1*max_speed)
                basespeed+= new Vector2(0f,-1*speed*speed_multiplier);
            pRacket.velocity = basespeed;
            FindObjectOfType<Ball>().Inheritspeed(basespeed.y);
        }
       

    }
    
    void clamp()
    {
        float clampHight = camera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y - (transform.localScale.y/2);
        Vector3 clampedPos = transform.position;
        clampedPos = new Vector3(transform.position.x, Mathf.Clamp(clampedPos.y, -clampHight, clampHight), transform.position.z);
        transform.position = clampedPos;
    }

}
