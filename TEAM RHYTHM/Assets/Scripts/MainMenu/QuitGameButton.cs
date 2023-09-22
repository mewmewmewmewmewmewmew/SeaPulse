using UnityEngine;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{
    public Button quitButton;

    private void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {  
        Application.Quit();
    }
}
