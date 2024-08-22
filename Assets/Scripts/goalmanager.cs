using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class scorehandler : MonoBehaviour
{
    
    public bool isp1goal;
    private GameObject Ball;
    public ScoreManager ScoreManager;
    
    void Start()
    {
        Ball = GameObject.FindWithTag("ball");
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("ball"))
        {
            if(isp1goal)
            {
                ScoreManager.Addscore2();
            }
            else
            {
              ScoreManager.Addscore1();  
            }
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {  
        Destroy(Ball);
        
    }
}
