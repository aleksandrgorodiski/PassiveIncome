﻿using UnityEngine;

public class GameElement : MonoBehaviour
{
    private ApplicationContext _app;
    public ApplicationContext app
    {
        get
        {
            if (null == _app)
            {
                _app = FindObjectOfType<ApplicationContext>();
            }
            return _app;
        }
    }
}

public class ApplicationContext : MonoBehaviour
{
    [Header("Configs")]
    public GlobalConfigs globalConfigs;

    [Header("Settings")]
    public GameSettings gameSettings;

    [Header("Elements")]
    public GameModel model;
    public GameView view;
    public GameController controller;
   
}
