using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuPanel;

    public void Continue()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Menu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
