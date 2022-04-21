using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Level[] levels;
    public GameObject player;
    public int currentLevel = 0;

    private void Awake()
    {
        instance = this;
    }

    public void GotoNextLevel()
    {
        currentLevel++;
        if(currentLevel < levels.Length)
            player.transform.position = levels[currentLevel].levelRestart.position;
        //reset timer
    }
}
