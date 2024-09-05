using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

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
    public AudioMixer MasterMixer;
    

    public SoundAudioClip[] soundAudioClipArray;
    [System.Serializable]
    public class SoundAudioClip
    {
        public AudioManager.Sounds Sounds;
        public AudioClip AudioClip;
    }

    public SoundAudioClip[] MusicTrackArray;
    [System.Serializable]
    public class MusicTrack
    {
        public AudioManager.Tracks Tracks;
        public AudioClip AudioClip;
        public float bpm= 130f;
        public float TimeToFirstBeat=0;
        public float TailEndTime=0;
    }

}
