using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 0;
    [SerializeField] private TMP_Text timeText;

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (timeRemaining >= 0)
        {
            timeRemaining += Time.deltaTime;
            DisplayTime(timeRemaining);
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        UpdateTimeText(minutes, seconds);
    }

    private void UpdateTimeText(float minutes, float seconds)
    {
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
