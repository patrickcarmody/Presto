using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

//This has the same functions as LevelSystem, but levels gradually increase so it can be used with UI Animations (i.e. the level bar)
public class LevelSystemAnimated
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private LevelSystem levelSystem;
    private bool isAnimating;
    private float updateTimer;
    private float updateTimerMax;

    private int level;
    private int experience;

    public LevelSystemAnimated(LevelSystem levelSystem)
    {
        SetLevelSystem(levelSystem);
        updateTimerMax = .016f;
        FunctionUpdater.Create(() => Update()); //Call on every update
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        level = levelSystem.GetLevelNumber();
        experience = levelSystem.GetExperience();
        
        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        isAnimating = true;
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        isAnimating = true;
    }

    private void Update()
    {
        if (isAnimating)
        {
            //Check if its time to update
            updateTimer += Time.deltaTime;
            while(updateTimer > updateTimerMax)
            {
                //Time to update
                updateTimer -= updateTimerMax;
                UpdateAddExperience();
            }
        }
    }

    private void UpdateAddExperience()
    {
        if (level < levelSystem.GetLevelNumber())
        {
            //Local level under target level
            AddExperience();
        }
        else
        {
            //Local level equalstarget level
            if (experience < levelSystem.GetExperience())
            {
                AddExperience();
            }
            else
            {
                isAnimating = false;
            }
        }
    }
    
    private void AddExperience()
    {
        experience++;
        if (experience >= levelSystem.GetExperienceToNextLevel(level))
        {
            level ++;
            experience = 0;
            if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExperienceNormalized()
    {
        if (levelSystem.IsMaxLevel(level))
        {
            return 1f;
        }
        else
        {
            return (float)experience / levelSystem.GetExperienceToNextLevel(level);
        }
        
    }

}