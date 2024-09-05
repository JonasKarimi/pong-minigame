using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public ParticleSystem prt;
    [SerializeField] float startingBallSpeed = 8;
    [SerializeField] float bannedStartAngleDgree;
    [SerializeField] float timeSinceLastPlayerHitThreshold = 5f;
    [SerializeField] float SpeedUpFactor = 1.0f;

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
            rb2d.AddForce(d * SpeedUpFactor, ForceMode2D.Force);
        }
    }
    private Vector2 dir;
    IEnumerator GoBall()
    {
        yield return new WaitForSeconds(1);
        float rand = UnityEngine.Random.Range(bannedStartAngleDgree, 180 - bannedStartAngleDgree) - 90;
        if (UnityEngine.Random.Range(0, 2) == 1) { rand += 180;}

        dir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * rand), Mathf.Sin(Mathf.Deg2Rad * rand));
        rb2d.velocity = ( dir * startingBallSpeed);
     
    }
    private float timeSinceLastPlayerHit = 0;
   public void  OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.collider.CompareTag("Player"))
        {
            timeSinceLastPlayerHit = 0f;
            ChangeTrajectory(collision);
        }
        AudioManager.PlaySound(AudioManager.Sounds.BallBounce,this.transform.position,0.6f);
        var em = prt.emission;
        em.enabled=true;
        prt.Play();
   }

    [SerializeField] float PaddleChangeDirFactor =1;
   void ChangeTrajectory(Collision2D _collision2D)
   {
        float keepSpeed = rb2d.velocity.magnitude;
        Vector3 newVel = rb2d.velocity + (_collision2D.collider.attachedRigidbody.velocity * PaddleChangeDirFactor);
        newVel = newVel.normalized * keepSpeed;
        rb2d.velocity = newVel;
   }
}
