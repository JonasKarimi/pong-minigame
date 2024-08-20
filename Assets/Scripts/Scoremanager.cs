using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScoreManager : MonoBehaviour
{
     
     public TextMeshProUGUI player1text;
     public  TextMeshProUGUI player2text;
   
    private int score1;
    private int score2;
    //redundant
    /*
    public static ScoreManager instance; 

     private void Awake()
     {
         instance =this;
     }      
     */
    void Start()
    {
      score1 =0; score2=0;
    }
    public void Addscore1()
    {
        score1++;
        player1text.text= score1.ToString();
    }
    public void Addscore2()
    {
        score2++;
        player2text.text= score2.ToString();
    }
}
