using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    [SerializeField] float Timepass=0f;
    bool keepTime=false;
    private void OnEnable()
    {
        EventManager.onStartGame += StartTimer;
        EventManager.onPlayerDeath += StopTimer;
    }
    private void OnDisable()
    {
        EventManager.onStartGame -= StartTimer;
        EventManager.onPlayerDeath -= StopTimer;
    }
    private void Update()
    {
        if (keepTime)
        {
            Timepass += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }
    private void StartTimer()
    {
        Timepass = 0;
        keepTime = true;
        //Debug.Log("Keep Time");
    }
    private void StopTimer()
    {
        keepTime = false;
    }
    void UpdateTimerDisplay()
    {
        int minutes;
        float seconds;
        minutes = Mathf.FloorToInt(Timepass / 60);
        seconds = Timepass % 60;
        timerText.text = string.Format("{0}:{1:00.00}", minutes, seconds);
    }
}
