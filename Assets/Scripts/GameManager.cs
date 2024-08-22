using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        GameManager.Spawner.SpawnBall();
        GameEvent.Pause();
    }
    public class GameEvent : MonoBehaviour
    {
        public delegate void EventHandler();
        public static event EventHandler Paused;
        public static event EventHandler UnPaused;
        public static bool IsPaused;

        public static void Pause()
        {
            if (Paused != null)
            {
                Paused();
            }
            Time.timeScale = 0f;
            IsPaused = true;
        }
        public static void UnPause()
        {
            if (Paused != null)
            {
                UnPaused();
            }
            Time.timeScale = 1f;
            IsPaused = false;
        }
    }
    public void Pause()
    {
        GameEvent.Pause();
    }
    public void UnPause()
    {
        GameEvent.UnPause();
    }

    public class Spawner
    {
        public static void SpawnBall()
        {
            if (GameAssets.Instance.Ball != null)
            {

                Instantiate(GameAssets.Instance.Ball, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Debug.Log("no ballsack dipshit");
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { ViewManager.Show<PauseView>(); GameEvent.Pause(); }
        if (GameObject.FindGameObjectWithTag("ball") == null)
        {
            GameManager.Spawner.SpawnBall();
        }
    }
}
