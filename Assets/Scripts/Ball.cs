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
    [SerializeField] float timeSinceLastPlayerHitThreshold = 5f;


    public float reletiveSpeed;
    private Vector2 dir;
    void Start()
    {
        rb2d =GetComponent<Rigidbody2D>();
        StartCoroutine(GoBall());
        
    }
    private void Update()
    {
        timeSinceLastPlayerHit += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Vector2 d = rb2d.velocity.normalized; 
        if (timeSinceLastPlayerHit >= timeSinceLastPlayerHitThreshold)
        {
            d *= Mathf.Pow(((timeSinceLastPlayerHit - timeSinceLastPlayerHitThreshold) + 0.2f)*0.5f,0.8f);
            rb2d.AddForce(d * 0.6f, ForceMode2D.Force);
        }
    }
    IEnumerator GoBall()
    {
        yield return new WaitForSeconds(1);
        float rand = Random.Range(bannedStartAngleDgree, 180 - bannedStartAngleDgree) - 90;
        if (Random.Range(0, 2) == 1) { rand += 180;}

        dir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * rand), Mathf.Sin(Mathf.Deg2Rad * rand));
        rb2d.velocity = ( dir * startingBallSpeed);
     
    }
    private float timeSinceLastPlayerHit = 0;
   public void  OnCollisionExit2D(Collision2D collision)
   {
        if (collision.collider.CompareTag("Player"))
        {
            timeSinceLastPlayerHit = 0f;
        //    rb2d.AddForce(new Vector2(0f, 10f * reletiveSpeed));
        //    Vector3 tempSpeed = rb2d.velocity += collision.gameObject.GetComponent<Rigidbody2D>().velocity;
        //    tempSpeed.Normalize();
        //    rb2d.velocity = tempSpeed * rb2d.velocity.magnitude;
        }

        AudioManager.PlaySound(AudioManager.Sounds.BallBounce,this.transform.position,0.6f);
        var em = prt.emission;
        em.enabled=true;
        prt.Play();
   }
}
