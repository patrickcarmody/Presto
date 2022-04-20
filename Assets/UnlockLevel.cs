using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    public int currentLevelUnlocked;
    public int thisLevel;
    void Awake()
    {
        currentLevelUnlocked = PlayerPrefs.GetInt("unlockedLevels");
        Debug.Log("Current levels unlocked: " + currentLevelUnlocked);
    }

    public void SetLevel(int level)
    {
        //Checks if player has already unlocked next levels
        if (currentLevelUnlocked <= thisLevel)
        {
            PlayerPrefs.SetInt("unlockedLevels", level);
            Debug.Log("Unlocked levels set to " + PlayerPrefs.GetInt("unlockedLevels"));
        }
        else
        {
            Debug.Log("Next level already unlocked.");
        }
    }
}