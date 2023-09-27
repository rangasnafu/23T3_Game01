using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float countdownTime = 60.0f; // 1 minute in seconds
    private bool isCounting = true;

    private void Update()
    {
        if (isCounting)
        {
            countdownTime -= Time.deltaTime;

            if (countdownTime <= 0.0f)
            {
                countdownTime = 0.0f;
                isCounting = false;
            }

            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);

        string timerString = minutes.ToString() + ":" + (seconds < 10 ? "0" : "") + seconds.ToString();
        timerText.text = timerString;
    }
}
