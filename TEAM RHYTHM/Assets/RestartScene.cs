using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    string levelName;
    public enum SceneName
    {
        SplashScreen,
        Menu,
        Tutorial,
        JPLD2Players,
        JPLD3Players,
        GameOver,
        Splash,
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
            case SceneName.Menu:
                levelName = "Menu";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.Tutorial:
                levelName = "Tutorial";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.JPLD2Players:
                levelName = "JPLD2 Players";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.JPLD3Players:
                levelName = "JPLD3 Players";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.GameOver:
                levelName = "GameO ver";
                SceneManager.LoadScene(levelName);
                break;
            case SceneName.Splash:
                levelName = "Splash";
                SceneManager.LoadScene(levelName);
                break;
        }
    }

}
