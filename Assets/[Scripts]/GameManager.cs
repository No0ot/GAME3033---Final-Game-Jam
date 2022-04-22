using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Level[] levels;
    public GameObject player;
    public GameObject pauseMenu;
    public int currentLevel = 0;

    public float timer;
    float timerMax = 10f;

    public GameObject winMenu;
    public GameObject loseMenu;

    private void Awake()
    {
        instance = this;
        timer = timerMax;
        Time.timeScale = 1f;
    }

    public void GotoNextLevel()
    {
        if (currentLevel < levels.Length - 1)
        {
            levels[currentLevel].gameObject.SetActive(false);
            currentLevel++;
            levels[currentLevel].gameObject.SetActive(true);
            if (currentLevel < levels.Length)
                player.transform.position = levels[currentLevel].levelRestart.position;
            player.GetComponent<PlayerController>().NewLevelStart();
            ResetTimer();
        }
        else
            WinGame();
        //reset timer
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            LoseGame();
            //lose game;
        }
    }

    public void ResetTimer()
    {
        timer = timerMax;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void WinGame()
    {
        Time.timeScale = 0;
        winMenu.SetActive(true);
    }

    public void LoseGame()
    {
        Time.timeScale = 0;
        loseMenu.SetActive(true);
    }
}
