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
        app.model.ON_MONTH_CHANGE += OnMonthChanged;
    }

    public void OnMonthChanged()
    {
        long _profitLastMonth = _balanceModel.incomePerMonth.Amount - _balanceModel.expensesPerMonth.Amount;
        AddSavings(_profitLastMonth);

        _balanceModel.profitPerMonth.Amount = _profitLastMonth;
    }

    //public void AddCurrency(CurrencyModel currencyModel)
    //{
    //    ulong _amount = currencyModel.Amount;
    //    ulong _value = Convert.ToUInt64(currencyModel.GetNominal());
    //    ulong _newAmount = _amount + _value;
    //    currencyModel.Amount = _newAmount;
    //}

    public void AddSavings(long _plusValue)
    {
        long _amount = _balanceModel.savings.Amount;
        long _value = _plusValue;
        long _newAmount = _amount + _value;
        _balanceModel.savings.Amount = _newAmount;
    }

    //public void MinusCurrency(CurrencyModel currencyModel, ulong _minusValue)
    //{
    //    Debug.Log("BalanceController. Minus: " + currencyModel.GetID() + ". Amount: " + currencyModel.Amount + ". Cost: " + _minusValue);
    //    ulong _amount = currencyModel.Amount;
    //    ulong _newAmount = _amount - _minusValue;
    //    currencyModel.Amount = _newAmount;
    //}


}
