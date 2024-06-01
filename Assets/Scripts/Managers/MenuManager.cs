using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _playButton, _menuSelectPanel;
    [SerializeField] private TextMeshProUGUI _stateText;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged; 
    }

    private void GameManagerOnOnGameStateChanged(GameState state)
    {
        _menuSelectPanel.SetActive(state == GameState.Menu);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
