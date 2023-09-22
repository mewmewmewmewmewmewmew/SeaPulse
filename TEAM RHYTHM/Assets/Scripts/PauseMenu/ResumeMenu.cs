using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeMenu : MonoBehaviour
{
    private PauseMenu pauseMenu;

    private void Start()
    {
        // Find the GameObject with the PauseMenu script
        GameObject pauseMenuObject = GameObject.FindWithTag("PauseMenu");
        if (pauseMenuObject != null)
        {
            pauseMenu = pauseMenuObject.GetComponent<PauseMenu>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu != null && PauseMenu.GameIsPaused && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            // Call the Resume function from the PauseMenu script
            pauseMenu.Resume();
        }
    }
}
