using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Level[] levels;
    public GameObject player;
    public int currentLevel = 0;

    public float timer;
    float timerMax = 10f;

    private void Awake()
    {
        instance = this;
        timer = timerMax;
    }

    public void GotoNextLevel()
    {
        levels[currentLevel].gameObject.SetActive(false);
        currentLevel++;
        levels[currentLevel].gameObject.SetActive(true);
        if(currentLevel < levels.Length)
            player.transform.position = levels[currentLevel].levelRestart.position;
        player.GetComponent<PlayerController>().NewLevelStart();
        ResetTimer();
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
            //lose game;
        }
    }

    public void ResetTimer()
    {
        timer = timerMax;
    }
}
