using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text levelText;

    private void Update()
    {
        float sec = GameManager.instance.timer;
        sec = (Mathf.Round(sec * 1000) / 1000);
        float color = sec / 10;
        timerText.text = sec.ToString();
        timerText.color = new Color(1.0f, color, color);

        levelText.text = "Level: " + (GameManager.instance.currentLevel + 1);
    }
}
