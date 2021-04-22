using UnityEngine;
using System;

public class BalanceController: GameElement
{
    public BalanceModel _balanceModel
    {
        get => app.model.balanceModel;
    }

    public void LoadBalance()
    {
        _balanceModel.savings.Load();
        _balanceModel.incomePerMonth.Load();
        _balanceModel.expensesPerMonth.Load();
        _balanceModel.profitPerMonth.Load();
    }

    private void Start()
    {
        app.model.ON_DATE_CHANGE += OnMonthChanged;
    }

    public void OnMonthChanged()
    {
        long _profitLastMonth = _balanceModel.incomePerMonth.Amount - _balanceModel.expensesPerMonth.Amount;
        _balanceModel.profitPerMonth.Amount = _profitLastMonth;

        AddSavings(_profitLastMonth);
    }

    public void AddSavings(long _plusValue)
    {
        long _amount = _balanceModel.savings.Amount;
        long _value = _plusValue;
        long _newAmount = _amount + _value;
        _balanceModel.savings.Amount = _newAmount;
    }
}
