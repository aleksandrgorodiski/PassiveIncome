using System.Collections;
using TMPro;
using UnityEngine;
using Utilities;

public class BalanceView : GameElement
{
    public BalanceModel _balanceModel
    {
        get => app.model.balanceModel;
    }

    public BalanceHud balanceHud;

    private void Awake()
    {
        _balanceModel.incomePerMonth.ON_AMOUNT_CHANGE += OnIncomePerMonthChange;
        _balanceModel.expensesPerMonth.ON_AMOUNT_CHANGE += OnExpensesPerMonthChange;
        _balanceModel.profitPerMonth.ON_AMOUNT_CHANGE += OnProfitChange;
        _balanceModel.savings.ON_AMOUNT_CHANGE += OnSavingsChange;
    }

    private void OnDestroy()
    {
        _balanceModel.incomePerMonth.ON_AMOUNT_CHANGE -= OnIncomePerMonthChange;
        _balanceModel.expensesPerMonth.ON_AMOUNT_CHANGE -= OnExpensesPerMonthChange;
        _balanceModel.profitPerMonth.ON_AMOUNT_CHANGE -= OnProfitChange;
        _balanceModel.savings.ON_AMOUNT_CHANGE -= OnSavingsChange;
    }

    void OnSavingsChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.savingsText, prevValue, newValue, _balanceModel.savings.GetNameKey(),
            _balanceModel.savings.GetPrefixLocKey(), _balanceModel.savings.GetSuffixLocKey()));
    }
    void OnIncomePerMonthChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.incomeText, prevValue, newValue, _balanceModel.incomePerMonth.GetNameKey(),
            _balanceModel.incomePerMonth.GetPrefixLocKey(), _balanceModel.incomePerMonth.GetSuffixLocKey()));
    }
    void OnExpensesPerMonthChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.expensesText, prevValue, newValue, _balanceModel.expensesPerMonth.GetNameKey(),
            _balanceModel.expensesPerMonth.GetPrefixLocKey(), _balanceModel.expensesPerMonth.GetSuffixLocKey()));
    }
    void OnProfitChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.profitText, prevValue, newValue, _balanceModel.profitPerMonth.GetNameKey(),
            _balanceModel.profitPerMonth.GetPrefixLocKey(), _balanceModel.profitPerMonth.GetSuffixLocKey()));

        if (newValue < 0) balanceHud.profitSprite.color = balanceHud.redColor;
        else balanceHud.profitSprite.color = balanceHud.greenColor;
    }



    void SetText(TextMeshProUGUI _text, long _value, string _nameKey, string _prefixKey, string _suffixKey)
    {
        string locNameKey = LocalizedString(_nameKey);
        string locSuffixKey = LocalizedString(_suffixKey);
        string locCashSuffixKey = LocalizedString(MathUtil.LongToCashSuffix(_value));

        _text.text = locNameKey + ": "+  _prefixKey + MathUtil.LongToString(_value) + locCashSuffixKey + locSuffixKey;
    }

    string LocalizedString(string _value)
    {
        return app.controller.localization.GetLocalizedValue(_value);
    }

    IEnumerator CountTo(TextMeshProUGUI _text, long _prevValue, long _newValue, string _name, string _prefix, string _suffix)
    {
        long _score;
        float duration = 0.0f;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            _score = (long)Mathf.Lerp(_prevValue, _newValue, progress);
            SetText(_text, _score, _name, _prefix, _suffix);
            yield return null;
        }
        _score = _newValue;
        SetText(_text, _newValue, _name, _prefix, _suffix);
    }
}
