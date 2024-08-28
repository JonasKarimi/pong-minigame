using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class ScoreHandler : MonoBehaviour
{
    
    public bool isp1goal;
    public ScoreManager ScoreManager;
    public ParticleSystem goaleffect;
    [SerializeField] int NoBitchCallingPercentage;
    
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("ball"))
        {
            if(isp1goal)
            {
                ScoreManager.Addscore2();
                var em = goaleffect.emission;
                em.enabled=true;
                goaleffect.Play();
                
                AudioManager.PlaySound(AudioManager.Sounds.Goal,this.transform.position);
                taunt();
            }
            else
            {
              ScoreManager.Addscore1(); 
                var em = goaleffect.emission;
                em.enabled=true;
                 goaleffect.Play();
                 AudioManager.PlaySound(AudioManager.Sounds.Goal,this.transform.position);
                 taunt();
                 
               
            }
            Destroy(col.gameObject);
        }
    }
    public void taunt()
    {
        int rand = Random.Range(0,100);
        if(rand<=NoBitchCallingPercentage)
        {
            AudioManager.PlaySound(AudioManager.Sounds.Taunt,this.transform.position);
        }

    }
}
