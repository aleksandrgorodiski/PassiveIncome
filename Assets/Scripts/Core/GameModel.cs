using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : GameElement
{
    public event Action ON_MONTH_CHANGE;

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
        get => _currentMonth;
        set
        {
            if (_currentMonth == value) return;
            _currentMonth = value;
            ON_MONTH_CHANGE?.Invoke();
        }
    }

    [SerializeField]
    private string _currentYear;
    public string CurrentYear
    {
        get => _currentYear;
        set
        {
            if (_currentYear == value) return;
            _currentYear = value;
        }
    }
}
