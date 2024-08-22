using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
    }
    public static AudioMixer MasterMixer;
    
}
