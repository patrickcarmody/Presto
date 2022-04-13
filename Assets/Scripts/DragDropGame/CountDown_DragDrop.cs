using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown_DragDrop : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 10f;
    public bool isRunning;
    public bool TimeUp;
    public GameObject WinScript;

    private int currentPoints;
    private int pointsToWin;

    [FMODUnity.EventRef]
    FMOD.Studio.EventInstance timerClicks;

    [SerializeField] Text countdownText;

    private void Start()
    {
        currentTime = startingTime;
        isRunning = false;
        timerClicks = FMODUnity.RuntimeManager.CreateInstance("event:/CountDown");
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime -= 1 * Time.deltaTime;
        }

        if (!isRunning)
        {
            currentTime = currentTime * 1;
        }
        //Get Points from Win Script
        currentPoints = WinScript.GetComponent<WinScript>().currentPoints;
        pointsToWin = WinScript.GetComponent<WinScript>().pointsToWin;

        //Print time to text
        countdownText.text = currentTime.ToString("0");
        
        if (currentTime <= 0)
        {
            //Stop timer at 0 seconds
            currentTime = 0;
            isRunning = false;
            TimeUp = true;
        }

        if (TimeUp)
        {
            //Show time up panel and stop timer audio
            transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Time has run out!");
        }

        //Change text colour
        if (currentTime <= 3)
        {
            countdownText.color = Color.red;
        }

        if (currentPoints >= pointsToWin)
        {
            TimeUp = false;
            StopAudio();
        }

    }
    public void StopAudio()
    {
        timerClicks.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //Debug.Log("Audio Stopped");
    }

    public bool GetRunning()
    {
        return isRunning;
    }

    public void StartTimer()
    {
        isRunning = true;
        timerClicks.start();
        //Debug.Log("Timer Started");
    }

    public void ResetTimer()
    {
        currentTime = startingTime;
        //Debug.Log("Timer Reset");
    }
}
