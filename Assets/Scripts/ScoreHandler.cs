using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreHandler : MonoBehaviour
{
    
    public bool isp1goal;
    public ScoreManager ScoreManager;
    
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
            Destroy(col.gameObject);
        }
    }
}
