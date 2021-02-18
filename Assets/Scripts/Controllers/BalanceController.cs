using UnityEngine;
using System;

public class BalanceController: GameElement
{
    public BalanceModel _balanceModel
    {
        get => app.model.balanceModel;
    }

    public void AddCurrency(CurrencyModel currencyModel)
    {
        ulong _amount = currencyModel.Amount;
        ulong _value = Convert.ToUInt64(currencyModel.GetNominal());
        ulong _newAmount = _amount + _value;
        currencyModel.Amount = _newAmount;
    }

    public void MinusCurrency(CurrencyModel currencyModel, ulong _value)
    {
        Debug.Log("BalanceController. Minus: " + currencyModel.GetID() + ". Amount: " + currencyModel.Amount + ". Cost: " + _value);
        ulong _amount = currencyModel.Amount;
        ulong _newAmount = _amount - _value;
        currencyModel.Amount = _newAmount;
    }

    public void LoadBalance()
    {
        _balanceModel.cashModel.LoadCurrency();
    }
}
