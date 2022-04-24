using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    GameObject newPlayerPanel, getStartedText;

    void Start()
    {
        if(PlayerPrefs.GetInt("HasPlayed", 0) == 0)
        {
            newPlayerPanel.SetActive(true);
            getStartedText.SetActive(true);
        }
        else
        {
            newPlayerPanel.SetActive(false);
            getStartedText.SetActive(false);
        }
    }

    public void PlayerStarted(int hasStarted)
    {
        PlayerPrefs.SetInt("HasPlayed", 1);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void RemoveGetStarted()
    {
        getStartedText.SetActive(false);

    }
}
