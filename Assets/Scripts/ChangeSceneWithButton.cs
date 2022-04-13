using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButton : MonoBehaviour
{
    private string nameOfScene;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        nameOfScene = sceneName;

    }

    public void BringObject(GameObject objectName)
    {
        SceneManager.MoveGameObjectToScene(objectName, SceneManager.GetSceneByName(nameOfScene));
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
