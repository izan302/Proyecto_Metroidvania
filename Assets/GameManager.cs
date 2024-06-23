using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public enum GameState {
        Running,
        Paused,
        DeadScreen,
        VictoryScreen
    }
    
    void Awake() {
        Instance = this;
    }

    void Start() {
        UpdateGameState(GameState.Running);
    }
    public void UpdateGameState(GameState newState) {
        State = newState;
        //Debug.Log("new: "+newState);
        switch (newState) {
            case GameState.Running:
                Time.timeScale = 1f;
            break;
            case GameState.Paused:
                Time.timeScale = 0f;
            break;
            case GameState.DeadScreen:
                Time.timeScale = 0f;
            break;
            case GameState.VictoryScreen:
                Time.timeScale = 0f;
            break;
        }
        OnGameStateChanged(newState);
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(State == GameState.Running) {
                UpdateGameState(GameState.Paused);
            }else if (State == GameState.Paused) {
                UpdateGameState(GameState.Running);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
