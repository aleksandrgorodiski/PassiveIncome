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
        _balanceModel.profit.Load();
    }

    float _time;
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _balanceModel.GetTimeUnitLenght())
        {
            _time = 0f;
            long _profitLastMonth = _balanceModel.incomePerMonth.Amount - _balanceModel.expensesPerMonth.Amount;
            AddSavings(_profitLastMonth);

            //_balanceModel.profit.Amount += _profitLastMonth;
            _balanceModel.profit.Amount = _profitLastMonth;

            //float _packsCountFloat = (float)CurrentBalance / (float)_balanceModel.GetDollarsInOnePack();
            //long _packsCount = (long)(_packsCountFloat);
            //long _packsCountAbsolute = (long)(Mathf.Abs(_packsCount));
            //if (_packsCount != 0)
            //{
            //    if (_packsCount > 0)
            //    {
            //        AddMoneyPack(_packsCountAbsolute);
            //    }
            //    else if (_packsCount < 0)
            //    {
            //        RemoveMoneyPack(_packsCountAbsolute);
            //    }
            //    CurrentBalance = CurrentBalance - (_packsCount * _balanceModel.GetDollarsInOnePack());
            //    _packsCountFloat = 0f;
            //    _packsCount = 0;
            //    _packsCountAbsolute = 0;
            //}
        }
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
