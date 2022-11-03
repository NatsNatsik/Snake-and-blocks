using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static bool GameOver;
    public static bool LevelCompleted;
    public GameObject GameOverPanel;
    public GameObject LevelCompletedPanel;

    public MovementSnake MovementSnake;
    public enum State
    {
        Playing,
        Won,
        Loss
    }

    public State CarrentState { get; private set; }

    public void OnPlayerDied()
    {
       
        GameOverPanel.SetActive(true);
        GameOver = true;
        MovementSnake.enabled = false;
    }

    public void OnPlayerReachedFinish()
    {
        LevelCompletedPanel.SetActive(true);
        LevelCompleted = true;
        LevelIndex++;
        MovementSnake.enabled = false;
      

    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt("LevelIndex", 0);
        private set
        {
            PlayerPrefs.SetInt("LevelIndex", value);
            PlayerPrefs.Save();
        }
    }


    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
       
        LevelCompleted = false;
        GameOver = false;
        CarrentState = State.Playing;
        Time.timeScale = 1;
    }
    void Update()
    {
        if ((LevelCompleted && LevelCompletedPanel.active == true) ||
            (GameOver && GameOverPanel.active == true))
            if (Input.GetMouseButton(0) & GameOverPanel == true)
            {
                //SceneManager.LoadScene(0);
                ReloadLevel();

            }

    }
}
