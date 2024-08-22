using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public ParticleSystem prt;
    [SerializeField] float startingBallSpeed = 8;
    [SerializeField] float bannedStartAngleDgree;
    [SerializeField] int relspeed_multiplier;
    
    
     public  AudioSource bounce_sfx;
     private float relspeed=0;
    private Vector2 dir;
    void Start()
    {
        rb2d =GetComponent<Rigidbody2D>();
        //bounce_sfx= GetComponent<AudioSource>();
        StartCoroutine(GoBall());
        
    }
    IEnumerator GoBall()
    {
        yield return new WaitForSeconds(1);
        float rand = Random.Range(bannedStartAngleDgree, 180 - bannedStartAngleDgree) - 90;
        if (Random.Range(0, 2) == 1) { rand += 180; }

        dir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * rand*2), Mathf.Sin(Mathf.Deg2Rad * rand*2));
        rb2d.velocity = ( dir * startingBallSpeed * 10f);
     
    }
    public void Inheritspeed(float yracket)
    {
        relspeed = yracket;
    }
   public void  OnCollisionEnter2D(Collision2D collision)
   {    
        //bounce_sfx.Play();
       
        rb2d.AddForce(new Vector2(0f,relspeed*relspeed_multiplier));
        
        var em = prt.emission;

        em.enabled=true;
        prt.Play();
        
    

       
   }
}
