using UnityEngine;
using System;
using System.Collections;

public sealed class BalanceController : IDisposable
{
    private BalanceView _balanceView;
    private BalanceModel _balanceModel;

    public BalanceController(BalanceView balanceView)
    {
        _balanceView = balanceView;
        _balanceModel = new BalanceModel();
    }

    public BalanceController()
    {
    }

    public void LoadBalance()
    {
        _balanceModel.savings.Load();
        _balanceModel.incomePerMonth.Load();
        _balanceModel.expensesPerMonth.Load();
        _balanceModel.profitPerMonth.Load();
    }

    float _currentTime;
    public void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _balanceModel.GetTimeUnitLenght())
        {
            _currentTime = 0f;
            long _profitLastMonth = _balanceModel.incomePerMonth.Amount - _balanceModel.expensesPerMonth.Amount;
            AddSavings(_profitLastMonth);

            _balanceModel.profitPerMonth.Amount = _profitLastMonth;
        }
    }

    //test1
    //public void AddCurrency(CurrencyModel currencyModel)
    //{
    //    ulong _amount = currencyModel.Amount;
    //    ulong _value = Convert.ToUInt64(currencyModel.GetNominal());
    //    ulong _newAmount = _amount + _value;
    //    currencyModel.Amount = _newAmount;
    //}

    //test
    public void AddSavings(long _plusValue)
    {
        //long _amount = _balanceModel.savings.Amount;
        //long _value = _plusValue;
        //long _newAmount = _amount + _value;
        //_balanceModel.savings.Amount = _newAmount;
    }

    //public void MinusCurrency(CurrencyModel currencyModel, ulong _minusValue)
    //{
    //    Debug.Log("BalanceController. Minus: " + currencyModel.GetID() + ". Amount: " + currencyModel.Amount + ". Cost: " + _minusValue);
    //    ulong _amount = currencyModel.Amount;
    //    ulong _newAmount = _amount - _minusValue;
    //    currencyModel.Amount = _newAmount;
    //}

    public void Start()
    {
        _balanceModel.savings.ON_AMOUNT_CHANGE += _balanceView.OnSavingsChange;
        _balanceModel.incomePerMonth.ON_AMOUNT_CHANGE += _balanceView.OnIncomePerMonthChange;
        _balanceModel.expensesPerMonth.ON_AMOUNT_CHANGE += _balanceView.OnExpensesPerMonthChange;
        _balanceModel.profitPerMonth.ON_AMOUNT_CHANGE += _balanceView.OnProfitChange;

        _balanceView.SetIcon(BalanceType.Savings, true, _balanceModel.savings.GetSpriteID());
        _balanceView.SetIcon(BalanceType.Income, true, _balanceModel.incomePerMonth.GetSpriteID());
        _balanceView.SetIcon(BalanceType.Expenses, true, _balanceModel.expensesPerMonth.GetSpriteID());
        _balanceView.SetIcon(BalanceType.Profit, true, _balanceModel.profitPerMonth.GetSpriteID());

        _balanceView.SetText(BalanceType.Savings, false, _balanceModel.savings.GetSpriteID());
        _balanceView.SetText(BalanceType.Income, false, _balanceModel.incomePerMonth.GetSpriteID());
        _balanceView.SetText(BalanceType.Expenses, false, _balanceModel.expensesPerMonth.GetSpriteID());
        _balanceView.SetText(BalanceType.Profit, false, _balanceModel.profitPerMonth.GetSpriteID());


        //_balanceView.SetSavingsIcon();
        //_balanceView.SetIncomeIcon(_balanceModel.savings.GetSpriteID());
        //_balanceView.SetExpensesIcon(_balanceModel.savings.GetSpriteID());
        //_balanceView.SetProfitIcon(_balanceModel.savings.GetSpriteID());


        //SetIcon(balanceHud.savingsIconText, _balanceModel.savings.GetSpriteID());
        //SetIcon(balanceHud.incomeIconText, _balanceModel.incomePerMonth.GetSpriteID());
        //SetIcon(balanceHud.expensesIconText, _balanceModel.expensesPerMonth.GetSpriteID());
        //SetIcon(balanceHud.profitIconText, _balanceModel.profitPerMonth.GetSpriteID());

        //SetText(balanceHud.savingsText, balanceHud.savingsIconText, _balanceModel.savings.Amount, _balanceModel.savings.GetSuffix());
        //SetText(balanceHud.incomeText, balanceHud.incomeIconText, _balanceModel.incomePerMonth.Amount, _balanceModel.incomePerMonth.GetSuffix());
        //SetText(balanceHud.expensesText, balanceHud.expensesIconText, _balanceModel.expensesPerMonth.Amount, _balanceModel.expensesPerMonth.GetSuffix());
        //SetText(balanceHud.profitText, balanceHud.profitIconText, _balanceModel.profitPerMonth.Amount, _balanceModel.profitPerMonth.GetSuffix());
    }

    public void Dispose()
    {
        _balanceModel.savings.ON_AMOUNT_CHANGE -= _balanceView.OnSavingsChange;
        _balanceModel.incomePerMonth.ON_AMOUNT_CHANGE -= _balanceView.OnIncomePerMonthChange;
        _balanceModel.expensesPerMonth.ON_AMOUNT_CHANGE -= _balanceView.OnExpensesPerMonthChange;
        _balanceModel.profitPerMonth.ON_AMOUNT_CHANGE -= _balanceView.OnProfitChange;
    }
}
