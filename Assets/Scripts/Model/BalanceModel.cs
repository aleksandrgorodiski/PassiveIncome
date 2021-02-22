using UnityEngine;
using System;

[Serializable]
public class BalanceModel
{
    [SerializeField]
    private float _timeUnitLength = 1f;
    [Header("Dollars In One Pack")]
    [SerializeField]
    private long _dollarsInOnePack = 10000;
    [Header("Savings")]
    public CurrencyModel savings;
    [Header("Income")]
    public CurrencyModel incomePerMonth;
    [Header("Expenses")]
    public CurrencyModel expensesPerMonth;
    [Header("Profit")]
    public CurrencyModel profit;

    public float GetTimeUnitLenght()
    {
        return _timeUnitLength;
    }

    public long GetDollarsInOnePack()
    {
        return _dollarsInOnePack;
    }
}
