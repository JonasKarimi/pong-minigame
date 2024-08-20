using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    private int score=0;
    public static ScoreManager instance;

    private void awake()
    {
        instance =this;
    }


    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Addscore()
    {
        score+=1;
        scoreText.text = score.ToString();
    }
}
