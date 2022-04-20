using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLocks : MonoBehaviour
{
    // Start is called before the first frame update
    public int unlockedLevel;

    //Attack level locks in Unity Editor
    [SerializeField]
    private GameObject lock2, lock3, lock4, lock5, lock6, lock7, lock8, lock9;

    // Update is called once per frame
    private void Awake()
    {
        unlockedLevel = PlayerPrefs.GetInt("unlockedLevels");
    }

    void Update()
    {
        //Gets number of unlocked levels from PlayerPrefs and saves it as unlockedLevel
        unlockedLevel = PlayerPrefs.GetInt("unlockedLevels");
        CheckLevels();
    }

    public void SetLevel(int level)
    {
        PlayerPrefs.SetInt("unlockedLevels", level);
        Debug.Log("Unlocked levels set to " + PlayerPrefs.GetInt("unlockedLevels"));
    }

    void CheckLevels()
    {
        //Unlocks levels based on the unlockedLevels variable;
        if (unlockedLevel >= 2)
        {
            lock2.SetActive(false);
        }

        if (unlockedLevel >= 3)
        {
            lock3.SetActive(false);
        }

        if (unlockedLevel >= 4)
        {
            lock4.SetActive(false);
        }

        if (unlockedLevel >= 5)
        {
            lock5.SetActive(false);
        }

        if (unlockedLevel >= 6)
        {
            lock6.SetActive(false);
        }

        if (unlockedLevel >= 7)
        {
            lock7.SetActive(false);
        }

        if (unlockedLevel >= 8)
        {
            lock8.SetActive(false);
        }

        if (unlockedLevel >= 9)
        {
            lock9.SetActive(false);
        }
    }

    public void ResetLevels()
    {
        //Resets unlocked levels to deafult (1)
        PlayerPrefs.SetInt("unlockedLevels", 1);
    }
}
