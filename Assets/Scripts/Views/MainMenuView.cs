using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenueView : View
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button QuitButton;
    [SerializeField] private Button SettingsButton;
    public override void Initialize()
    {
        PlayButton.onClick.AddListener(() => ViewManager.Show<PlayView>());
        PlayButton.onClick.AddListener(GameManager.GameEvent.UnPause);
        SettingsButton.onClick.AddListener(() => ViewManager.Show<SettingsView>());
        QuitButton.onClick.AddListener(() => Application.Quit());
    }
}
