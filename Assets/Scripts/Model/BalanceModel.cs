using UnityEngine;
using System;

[Serializable]
public class BalanceModel
{
    [Header("Income")]
    public CurrencyModel incomePerMonth;
    [Header("Expenses")]
    public CurrencyModel expensesPerMonth;
    [Header("Profit")]
    public CurrencyModel profitPerMonth;
    [Header("Savings")]
    public CurrencyModel savings;


    [SerializeField]
    private float _countDuration = 0.1f;
    public float GetCountDuration()
    {
        return _countDuration;
    }
}
