using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScoreManager : MonoBehaviour
{
     
     private TextMeshPro TMP;
   
    private int score=0;
    public static ScoreManager instance;

    private void Awake()
    {
        instance =this;
    }
    void Start()
    {
      TMP= GetComponent<TextMeshPro>();
    }
    public void Addscore(TMP_Text tmp)
    {
        score+=1;
        TMP.SetText(score.ToString());
    }
}
