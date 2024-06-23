using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu, DeathMenu, WinMenu;
    void Awake()
    {
        GameManager.OnGameStateChanged += GamemanagerOnGameStateChanged;
    }
    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GamemanagerOnGameStateChanged;
    }
    private void GamemanagerOnGameStateChanged(GameManager.GameState state)
    {
        switch (state)
        {
            case GameManager.GameState.Paused:
                pauseMenu.SetActive(true);
                break;
            case GameManager.GameState.DeadScreen:
                DeathMenu.SetActive(true);
                break;
            case GameManager.GameState.VictoryScreen:
                WinMenu.SetActive(true);
                break;
            case GameManager.GameState.Running:
                pauseMenu.SetActive(false);
                DeathMenu.SetActive(false);
                WinMenu.SetActive(false);
                break;
        }
    }
    public void UnPause()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Running);
    }
    public void GoToMainMenu()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Running);
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
