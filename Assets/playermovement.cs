using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] float speed =0.1f;
    [SerializeField] int  speed_multiplier=1;
    [SerializeField] int max_speed =5;
    private Rigidbody2D pRacket;

    // Start is called before the first frame update
    void Start()
    {
        pRacket = this.GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        Vector2 basespeed = new Vector2 (0f,0f);
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if(basespeed.y<max_speed)
                basespeed+= new Vector2(0f,speed*speed_multiplier);
            pRacket.velocity = basespeed; 
            
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(basespeed.y>-1*max_speed)
                basespeed+= new Vector2(0f,-1*speed*speed_multiplier);
            pRacket.velocity = basespeed;
        }
       

    }

}
