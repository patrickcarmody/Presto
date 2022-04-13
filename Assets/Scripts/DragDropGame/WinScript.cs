using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public int pointsToWin;
    public int currentPoints;
    public GameObject myNotes;
    public GameObject countdown;
    bool timerRunning;

    private void Start()
    {
        pointsToWin = myNotes.transform.childCount;
        
    }

    private void Update()
    {
        //Get isRunning Status from countdown
        timerRunning = countdown.GetComponent<CountDown_DragDrop>().isRunning;
        if (currentPoints >= pointsToWin)
        {
            //ON COMPLETION
            transform.GetChild(0).gameObject.SetActive(true);
            //STOP TIMER!
        }

        if(!timerRunning)
        {
            countdown.GetComponent<CountDown_DragDrop>().StopAudio();
        }
        
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}