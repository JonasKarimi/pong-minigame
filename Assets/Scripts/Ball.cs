using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] float startingBallSpeed = 8;
    [SerializeField] float bannedStartAngleDgree;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GoBall();
    }
    private Vector2 dir;
    void GoBall()
    {
        float rand = Random.Range(bannedStartAngleDgree, 180 - bannedStartAngleDgree) - 90;
        if (Random.Range(0, 2) == 1) { rand += 180; }
        dir = new Vector2(Mathf.Cos(Mathf.Deg2Rad * rand), Mathf.Sin(Mathf.Deg2Rad * rand));
        rb2d.velocity = ( dir * startingBallSpeed * 10f);
    }
    void bounce()
    {

    }
    //private void Update()
    //{
    //    float rand = Random.Range(bannedStartAngleDgree, 180 - bannedStartAngleDgree) -90;
    //    if (Random.Range(0,2) == 1) {rand += 180; }
    //    Debug.DrawRay(Vector3.zero, new Vector3(Mathf.Cos(Mathf.Deg2Rad * rand), Mathf.Sin(Mathf.Deg2Rad * rand),0f));
    //}
}
