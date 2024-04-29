using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    

    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject settingsMenuUI;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void OpenSettings()
    {

        settingsMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }
    public void closeSettings()
    {

        settingsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    } 
}

