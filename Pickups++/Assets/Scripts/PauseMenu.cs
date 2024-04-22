using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    bool settingsOpen;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject settingsMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused && settingsOpen)
            {
                closeSettings();
            }
            else if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }
    public void OpenSettings()
    {
        settingsOpen = true;
        settingsMenuUI.SetActive(true);
    }
    public void closeSettings()
    {
        settingsOpen = false;
        settingsMenuUI.SetActive(false);
    }
}
