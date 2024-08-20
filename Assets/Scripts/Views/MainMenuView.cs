using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenueView : View
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button QuitButton;
    public override void Initialize()
    {
        PlayButton.onClick.AddListener(() => ViewManager.Show<PlayView>());
        QuitButton.onClick.AddListener(() => Application.Quit());
    }
}
