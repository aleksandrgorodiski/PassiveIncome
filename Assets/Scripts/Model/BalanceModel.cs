using UnityEngine;
using System;

[Serializable]
public class BalanceModel
{
    [Header("Savings")]
    public CurrencyModel savings;
    [Header("Income")]
    public CurrencyModel incomePerMonth;
    [Header("Expenses")]
    public CurrencyModel expensesPerMonth;
    [Header("Profit")]
    public CurrencyModel profitPerMonth;
}
