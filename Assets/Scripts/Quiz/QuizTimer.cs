using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizTimer : MonoBehaviour
{
    public float startingTime = 15f;
    float currentTime = 0f;
    public bool isRunning = false;
    public bool timeUp;
    public bool gameFinished;

    [FMODUnity.EventRef]
    FMOD.Studio.EventInstance clockTick;


    [SerializeField] Text countDownText;

    void Start()
    {
        currentTime = startingTime;
        clockTick = FMODUnity.RuntimeManager.CreateInstance("event:/CountDown");
        gameFinished = false;
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= 1 * Time.deltaTime;
            countDownText.text = currentTime.ToString("0");
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            timeUp = true;
        }
    }

    public void startTimer()
    {
        isRunning = true;
        clockTick.start();
    }

    public void PauseTimer()
    {
        isRunning = false;
        clockTick.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void ResetTimer()
    {
        currentTime = startingTime;
        Time.timeScale = 1;
        clockTick.start();
        isRunning = true;
    }

    public void EndGame()
    {
        clockTick.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void StopTimerAudio()
    {
        clockTick.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}