using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public TextMeshProUGUI timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;

        BeginTimer();
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    IEnumerator UpdateTimer()
    {
        while(timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
