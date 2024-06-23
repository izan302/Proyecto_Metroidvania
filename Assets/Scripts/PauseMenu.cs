using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenu;
    public bool isPaused;
    public GameObject deathScreen;
    public GameObject endScreen;
    
    void Start()
    {
        pauseMenu.SetActive(false);
        deathScreen.SetActive(false);
        endScreen.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            } else {PauseGame(); }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    // Update is called once per frame
    public void ResumeGame()
    {
        pauseMenu.SetActive(false );
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DeathScreen() {
        deathScreen.SetActive(true);
    }

    public void EndScreen() {
        endScreen.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
