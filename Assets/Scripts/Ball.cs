using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] float startingBallSpeed = 8;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GoBall();
    }
    void GoBall()
    {
        float rand = Random.Range(0, 360);
        rb2d.AddForce(new Vector2(Mathf.Sin(rand), Mathf.Cos(rand))  * startingBallSpeed *10);
    }
}
