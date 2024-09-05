
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
public class SettingsView : View
{
    [SerializeField] Button BackButton;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider MusicSlider;
    public override void Initialize()
    {
        BackButton.onClick.AddListener(() => ViewManager.ShowLast());
    }
}
