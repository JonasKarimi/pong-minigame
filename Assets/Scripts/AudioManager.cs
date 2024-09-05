using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] static AudioMixer MasterMixer;
    [SerializeField] Slider[] SfxSliders;
    [SerializeField] Slider[] MusicSliders;
    public static float SfxVolume;
    public static float MusicVolume;
    public void Awake()
    {
        Instance = this;
        MasterMixer = GameAssets.Instance.MasterMixer;
        AudioManager.PlaySoundGlobal(AudioManager.Sounds.MainMusic);
    }

    public enum Tracks
    {

    }
    public enum Sounds
    {
        BallBounce,
        Goal,
        Taunt,
        MainMusic
    }
    public static void PlaySound(Sounds _sound, Vector3 _SoundPosition, float _Volume = 1, SoundGroup _SoundGroup = SoundGroup.Sfx)
    {
        GameObject SoundObject = new GameObject("SoundInstance");
        SoundObject.transform.position = _SoundPosition;
        AudioSource audioSource = SoundObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(_sound);
        audioSource.volume = _Volume;
        
        if(_SoundGroup == SoundGroup.Sfx ) { AudioMixerGroup g = MasterMixer.FindMatchingGroups("Sfx")[0]; audioSource.outputAudioMixerGroup = g; }
        if (_SoundGroup == SoundGroup.Music) { AudioMixerGroup g = MasterMixer.FindMatchingGroups("Music")[0]; audioSource.outputAudioMixerGroup = g; }
        audioSource.Play();
        Object.Destroy(SoundObject, audioSource.clip.length);
    }

    public static void PlaySoundGlobal(Sounds _sound, float _Volume = 1, SoundGroup _SoundGroup = SoundGroup.Sfx)
    {
        GameObject SoundObject = new GameObject("SoundInstance");
        AudioSource audioSource = SoundObject.AddComponent<AudioSource>();
        audioSource.volume = _Volume;
        if (_SoundGroup == SoundGroup.Sfx) { AudioMixerGroup g = MasterMixer.FindMatchingGroups("Sfx")[0]; audioSource.outputAudioMixerGroup = g; }
        if (_SoundGroup == SoundGroup.Music) { AudioMixerGroup g = MasterMixer.FindMatchingGroups("Music")[0]; audioSource.outputAudioMixerGroup = g; }
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



    public enum SoundGroup { Sfx, Music }
    private void Start()
    {
        SetVolume(SoundGroup.Music, PlayerPrefs.GetFloat("SavedMusicVolume", 100));
        SetVolume(SoundGroup.Sfx, PlayerPrefs.GetFloat("SavedSfxVolume", 100));
    }
    public void SetVolume(SoundGroup _SoundGroup, float _volume)
    {
        if (_volume < 1)
        {
            _volume = 0.001f;
        }
        if (SoundGroup.Music.Equals(_SoundGroup))
        {
            for (int i = 0; i < MusicSliders.Length; i++)
            {
                RefreshSlider(MusicSliders[i], _volume);
                PlayerPrefs.SetFloat("SavedMusicVolume", _volume);
                MasterMixer.SetFloat("MusicVolume", Mathf.Log10(_volume / 100f) * 20f);
            }
        }
        if (SoundGroup.Sfx.Equals(_SoundGroup))
        {
            for (int i = 0; i < SfxSliders.Length; i++)
            {
                RefreshSlider(SfxSliders[i], _volume);
                PlayerPrefs.SetFloat("SavedSfxVolume", _volume);
                MasterMixer.SetFloat("SfxVolume", Mathf.Log10(_volume / 100f) * 20f);
            }
        }
    }
    public void SetMusicVolumeFromSlider()
    {
        for (int i = 0; i < MusicSliders.Length; i++)
        {
            SetVolume(SoundGroup.Music, MusicSliders[i].value);
        }
    }
    public void SetSfxVolumeFromSlider()
    {
        for (int i = 0; i<SfxSliders.Length; i++)
        {
            SetVolume(SoundGroup.Sfx, SfxSliders[i].value);
        }
    }
    public void RefreshSlider(Slider _slider, float _Value)
    {
        _slider.value = _Value;
    }

}

    
