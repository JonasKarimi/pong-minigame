using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score=0;
    public static ScoreManager instance;

    private void Awake()
    {
        instance =this;
    }
    void Start()
    {
        scoreText.text = score.ToString();
    }
    public void Addscore()
    {
        score+=1;
        scoreText.text = score.ToString();
    }
}
