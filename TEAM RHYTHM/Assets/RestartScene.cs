using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    string levelName;
    public enum SceneName
    {
        CylinderLevel,
        GameplayDemo,
        GameplayDemo1,
        GameplayDemo2,
        GameplayDemo3,
        GameplayDemo4,
        GameplayDemo5,
        GameplayDemo6
    }
    public SceneName sceneName;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    // Start is called before the first frame update
    public void SceneRestart()
    {

        switch (sceneName)
        {
            case SceneName.CylinderLevel:
                levelName = "CylinderLevel";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.GameplayDemo:
                levelName = "GameplayDemo";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.GameplayDemo1:
                levelName = "GameplayDemo 1";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.GameplayDemo2:
                levelName = "GameplayDemo 2";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.GameplayDemo3:
                levelName = "GameplayDemo 3";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.GameplayDemo4:
                levelName = "GameplayDemo 4";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.GameplayDemo5:
                levelName = "GameplayDemo 5";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.GameplayDemo6:
                levelName = "GameplayDemo 6";
                SceneManager.LoadScene(levelName);
                break;
        }
    }

}
