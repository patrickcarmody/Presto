using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript2 : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject myNotes;

    private void Start()
    {
        pointsToWin = myNotes.transform.childCount;

    }

    private void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            //ON COMPLETION
            transform.GetChild(0).gameObject.SetActive(true);
            //Need to add to XP Here maybe? 
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}
