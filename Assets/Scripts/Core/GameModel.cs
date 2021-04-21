using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.SceneManagement;

public class GameModel : GameElement
{
    public event Action ON_DATE_CHANGE;

    public BalanceModel balanceModel = new BalanceModel();

    [SerializeField]
    private float _timeUnitLength = 1f;
    [Header("Dollars In One Pack")]
    [SerializeField]
    private long _dollarsInOnePack = 10000;

    public float GetTimeUnitLenght()
    {
        return _timeUnitLength;
    }

    public long GetDollarsInOnePack()
    {
        return _dollarsInOnePack;
    }

    [SerializeField]
    private int _currentMonth;
    public int CurrentMonth
    {
        get => _currentMonth = PlayerPrefs.GetInt("current_month", DateTime.Now.Month);
        set
        {
            if (_currentMonth == value) return;
            _currentMonth = value;
            PlayerPrefs.SetInt("current_month", value);
            ON_DATE_CHANGE?.Invoke();
        }
    }

    [SerializeField]
    private int _currentYear;
    public int CurrentYear
    {
        get => _currentYear = PlayerPrefs.GetInt("current_year", DateTime.Now.Year);
        set
        {
            if (_currentYear == value) return;
            _currentYear = value;
            PlayerPrefs.SetInt("current_year", value);
        }
    }
}
