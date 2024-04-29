using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    bool settingsOpen;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject settingsMenuUI;
    [SerializeField] PlayerBehavior player;

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
        Cursor.lockState = CursorLockMode.Confined;
        player.cameraCanMove = false;

    }
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.cameraCanMove = true;
    }
    public void OpenSettings()
    {
        settingsOpen = true;
        settingsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void closeSettings()
    {
        settingsOpen = false;
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
