using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float startingTime = 15f;
    float currentTime = 0f;

    [FMODUnity.EventRef]
    FMOD.Studio.EventInstance clockTick;


    [SerializeField] Text countDownText;

    void Start()
    {
        currentTime = startingTime;
        clockTick = FMODUnity.RuntimeManager.CreateInstance("event:/CountDown");
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");          

        if (currentTime <= 0)
        {
            //Timer over
            currentTime = 0;
            //clockTick.stop(FMOD.Studio.STOP_MODE);
        }
    }

    void PauseTimer()
    {
        Time.timeScale = 0;
       // clockTick.stop();
    }

    void ResetTimer()
    {
        currentTime = startingTime;
        Time.timeScale = 1;
        clockTick.start();
    }
}
