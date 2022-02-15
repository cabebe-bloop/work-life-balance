using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopWatch : MonoBehaviour
{
    [SerializeField] float currentTime;
    public TMP_Text currentTimeText;
    [SerializeField] TMP_Text gameOverTime;
    [SerializeField] bool stopWatchRunning = false;
    
    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        if (stopWatchRunning)
        {
        currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:f");
    }

    public void StartStopWatch()
    {
        stopWatchRunning = true;
    }

    public void StopStopWatch()
    {
        stopWatchRunning = false;
        currentTimeText.enabled = false;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        gameOverTime.text = time.ToString(@"mm\:ss\:f");
    }
}
