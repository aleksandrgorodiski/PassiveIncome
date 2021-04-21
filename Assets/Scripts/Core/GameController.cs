using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameController : GameElement
{
    public BalanceController balanceController;
    public EffectController effectController;
    public PlayerController playerController;
    public LocalizationManager localization;

    private void Awake()
    {
        localization.SelectLocalizationLanguage();
        balanceController.LoadBalance();
    }

    void Update()
    {
        CalculateDate();

        if (Input.GetMouseButton(0)) CheckIfResetGame();
        else _resetTimeCurrent = 0f;
    }

    void FireEffect(CurrencyConfig _config, int _pieces, Vector3 _effectPosition)
    {
        effectController.FireEffect(_config, _pieces, _effectPosition + Vector3.up * 3f, null);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        Scene _scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(_scene.name);
    }

    float _currentTime;
    void CalculateDate()
    {
        _currentTime += Time.deltaTime;
        app.view.SetDateBar(1 - (_currentTime / app.model.GetTimeUnitLenght()));

        if (_currentTime >= app.model.GetTimeUnitLenght())
        {
            _currentTime = 0f;

            int _value = app.model.CurrentMonth;
            _value++;
            if (_value <= 12)
            {
                app.model.CurrentMonth = _value;
            }
            else
            {
                int value = app.model.CurrentYear;
                value++;
                app.model.CurrentYear = value;
                app.model.CurrentMonth = 1;
            }
        }
    }

    public float _resetTimeCurrent;

    void CheckIfResetGame()
    {
        _resetTimeCurrent += Time.deltaTime;
        if (_resetTimeCurrent > 3f)
        {
            _resetTimeCurrent = 0f;
            ResetGame();
        }
    }
}