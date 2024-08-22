
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
public class SettingsView : View
{
    [SerializeField] Button BackButton;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider MusicSlider;
    private AudioMixer masterMixer;
    public override void Initialize()
    {
        BackButton.onClick.AddListener(() => ViewManager.ShowLast());
        SetSfxVolume(PlayerPrefs.GetFloat("SfxVolume", 100));
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 100));
        if (AudioManager.MasterMixer != null)
        {
            masterMixer = AudioManager.MasterMixer;
            Debug.LogError("no audio mixer dipshit");
        }
    }
    public void SetMusicVolume(float _value)
    {
        if (_value < 1) 
        {
            _value = .001f;
            RefreshMusicSlider(_value);
            PlayerPrefs.SetFloat("MusicVolume", _value); 
            masterMixer.SetFloat("MusicVolume", Mathf.Log10(_value / 100) * 20f);
        }
    }
    public void SetSfxVolume(float _value)
    {
        if (_value < 1)
        {
            _value = .001f;
            RefreshSfxSlider(_value);
            PlayerPrefs.SetFloat("SfxVolume", _value);
            masterMixer.SetFloat("SfxVolume", Mathf.Log10(_value / 100) * 20f);
        }
    }
    public void SetSfxVolumeFromSlider()
    {
        SetSfxVolume(SFXSlider.value);
    }
    public void SetMusicVolumeFromSlider()
    {
        SetMusicVolume(MusicSlider.value);
    }
    private void RefreshSfxSlider(float _value)
    {
        SFXSlider.value = _value;
    }
    private void RefreshMusicSlider(float _value)
    {
        MusicSlider.value = _value;
    }
}
