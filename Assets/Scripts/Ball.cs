using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] float startingBallSpeed = 8;
    [SerializeField] float bannedStartAngleDgree;
    
     public float relspeed;
    private Vector2 dir;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
   public void  OnCollisionExit2D(Collision2D collision)
   {
        AudioManager.PlaySound(AudioManager.Sounds.BallBounce,this.transform.position,0.6f);
        rb2d.AddForce(new Vector2(0f,relspeed));
   }
}
