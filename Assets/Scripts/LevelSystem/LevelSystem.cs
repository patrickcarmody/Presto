using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//VIDEO https://youtu.be/kKCLMvsgAR0
public class LevelSystem
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private static readonly int[] experiencePerLevel = new[] { 100, 120, 140, 160, 180, 200, 220, 250, 300, 400 };
    private int level;
    private int experience;
    
    public LevelSystem()
    {
        level = 0;
        experience = 0;
    }

    public void AddExperience(int amount)
    {
        if(!IsMaxlevel())
        {
            experience += amount;
            while (!IsMaxlevel() && experience >= GetExperienceToNextLevel(level))
            {
                experience -= GetExperienceToNextLevel(level);
                level++;
                if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
            }
            if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
        }
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExperienceNormalized()
    {
        if (IsMaxlevel())
        {
            return 1f;
        }
        else
        {
            return (float)experience / GetExperienceToNextLevel(level);
        }
        
    }

    public int GetExperience()
    {
        return experience;
    }

    public int GetExperienceToNextLevel(int level)
    {
        if(level < experiencePerLevel.Length)
        {
            return experiencePerLevel[level];
        }
        else
        {
            //Level Invalid
            Debug.LogError("Level invalid: " + level);
            return 100;
        }
        
    }
    public bool IsMaxlevel()
    {
        return IsMaxLevel(level);
    }

    public bool IsMaxLevel(int level)
    {
        return level == experiencePerLevel.Length - 1;
    }

}
