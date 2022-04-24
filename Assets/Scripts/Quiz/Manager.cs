using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject[] Levels;
    public GameObject ResetScreen, End, Correct, outOfTime;
    public GameObject LevelTimer;

    int currentLevel;

    public void wrongAnswer()
    {
        ResetScreen.SetActive(true);
        LevelTimer.GetComponent<QuizTimer>().EndGame();
    }

    private void Update()
    {
            if (LevelTimer.GetComponent<QuizTimer>().timeUp)
            {
                OutOfTime();
            }
    }

    public void correctAnswer()
    {
        if (currentLevel + 1 != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);

            currentLevel++;
            Levels[currentLevel].SetActive(true);
            correctScreen();
        }
        else
        {
            End.SetActive(true);
            Levels[currentLevel].SetActive(false);
            LevelTimer.GetComponent<QuizTimer>().EndGame();
        }
    }

    public void correctScreen()
    {
        Debug.Log("Show Correct Screen");
        Correct.SetActive(true);
        Invoke("returnToGame", 1.5f);
        LevelTimer.GetComponent<QuizTimer>().PauseTimer();
    }

    public void returnToGame()
    {
        Correct.SetActive(false);
        LevelTimer.GetComponent<QuizTimer>().ResetTimer();
    }

    public void OutOfTime()
    {
        outOfTime.SetActive(true);
        LevelTimer.GetComponent<QuizTimer>().EndGame();
    }
}