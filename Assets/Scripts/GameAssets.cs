using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _instance;

    public static GameAssets Instance {
        get 
        {
            if (_instance == null) { _instance = Instantiate(Resources.Load(("GameAssets")) as GameObject).GetComponent<GameAssets>(); }
            return _instance; 
        } 
    }

    public GameObject Ball;
    

    public SoundAudioClip[] soundAudioClipArray;
    [System.Serializable]
    public class SoundAudioClip
    {
        public AudioManager.Sounds Sounds;
        public AudioClip AudioClip;
    }
    
}
