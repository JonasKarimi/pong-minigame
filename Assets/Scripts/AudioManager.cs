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

    public enum Sounds
    {
        BallBounce,
        Goal,
        Taunt,
        MainMusic
    }
    public static AudioMixer MasterMixer;

    public static void PlaySound(Sounds _sound, Vector3 _SoundPosition, float _Volume = 1)
    {
        GameObject SoundObject = new GameObject("SoundInstance");
        SoundObject.transform.position = _SoundPosition;
        AudioSource audioSource = SoundObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(_sound);
        audioSource.volume = _Volume;
        audioSource.Play();
        Object.Destroy(SoundObject, audioSource.clip.length);
    }

    public static void PlaySoundGlobal(Sounds _sound, float _Volume = 1)
    {
        GameObject SoundObject = new GameObject("SoundInstance");
        AudioSource audioSource = SoundObject.AddComponent<AudioSource>();
        audioSource.volume = _Volume;
        audioSource.PlayOneShot(GetAudioClip(_sound));
        audioSource.Play();
        Object.Destroy(SoundObject, audioSource.clip.length);
    }

    public static AudioClip GetAudioClip(Sounds sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.Instance.soundAudioClipArray) {
            if (soundAudioClip.Sounds == sound)
            {
                return soundAudioClip.AudioClip;
            }
        }
        Debug.LogError("no " + sound + "Sound Dipshit");
        return null;
    }
}
