using UnityEngine;
using System;

public class BalanceController: GameElement
{
    public BalanceModel _balanceModel
    {
        get => app.model.balanceModel;
    }

    //public void AddCurrency(CurrencyModel currencyModel)
    //{
    //    ulong _amount = currencyModel.Amount;
    //    ulong _value = Convert.ToUInt64(currencyModel.GetNominal());
    //    ulong _newAmount = _amount + _value;
    //    currencyModel.Amount = _newAmount;
    //}

    public void AddCurrency(ulong _plusValue)
    {
        ulong _amount = _balanceModel.cashModel.Amount;
        ulong _value = _plusValue;
        ulong _newAmount = _amount + _value;
        _balanceModel.cashModel.Amount = _newAmount;
    }

    //public void MinusCurrency(CurrencyModel currencyModel, ulong _minusValue)
    //{
    //    Debug.Log("BalanceController. Minus: " + currencyModel.GetID() + ". Amount: " + currencyModel.Amount + ". Cost: " + _minusValue);
    //    ulong _amount = currencyModel.Amount;
    //    ulong _newAmount = _amount - _minusValue;
    //    currencyModel.Amount = _newAmount;
    //}

    public void LoadBalance()
    {
        _balanceModel.cashModel.LoadCurrency();
    }
}
