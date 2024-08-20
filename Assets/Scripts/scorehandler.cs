using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class scorehandler : MonoBehaviour
{
    BoxCollider2D trigger;
    [SerializeField] public TMP_Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        trigger = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        ScoreManager.instance.Addscore(scoreText);

    }
}
