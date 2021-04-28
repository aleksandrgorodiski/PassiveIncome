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
        StartCoroutine(CountTo(balanceHud.savingsText, app.view.greenColor, prevValue, newValue, _balanceModel.savings.GetNameLocKey(),
            _balanceModel.savings.GetPrefixLocKey(), _balanceModel.savings.GetSuffixLocKey()));

        if (_balanceModel.profitPerMonth.Amount > 0)
        {
            long milestoneValue1 = 1000000;
            long milestoneValue2 = 100000;

            string _line1 = app.controller.localization.GetLocalizedValue("savings_forecast") + ":";
            string _line2 = Line(milestoneValue1, AchievementYear(newValue, milestoneValue1));
            string _line3 = Line(milestoneValue2, AchievementYear(newValue, milestoneValue2));
            balanceHud.savingsForecastText.text = _line1 + "\n" + _line2 + "\n" + _line3;
        }
    }

    long AchievementYear(long savings, long milestone)
    {
        long leftToEarnCash = milestone - savings;
        long leftToEarnYear = (leftToEarnCash / _balanceModel.profitPerMonth.Amount) / 12;
        return app.model.CurrentYear + leftToEarnYear;
    }
    
    string Line(long milestone, long year)
    {
        return "<color=" + app.view.StringColor(app.view.greenColor) + ">" + MathUtil.LongToCashString(milestone) + "</color>" +
                app.controller.localization.GetLocalizedValue(MathUtil.LongToCashSuffixKey(milestone)) + " - " +
                "<color=" + app.view.StringColor(app.view.yellowColor) + ">" + year + "</color>" +
                app.controller.localization.GetLocalizedValue("name_year");
    }

    void OnIncomePerMonthChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.incomeText, app.view.greenColor, prevValue, newValue, _balanceModel.incomePerMonth.GetNameLocKey(),
            _balanceModel.incomePerMonth.GetPrefixLocKey(), _balanceModel.incomePerMonth.GetSuffixLocKey()));
    }
    void OnExpensesPerMonthChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.expensesText, app.view.redColor, prevValue, newValue, _balanceModel.expensesPerMonth.GetNameLocKey(),
            _balanceModel.expensesPerMonth.GetPrefixLocKey(), _balanceModel.expensesPerMonth.GetSuffixLocKey()));
    }
    void OnProfitChange(long prevValue, long newValue)
    {
        Color color;
        if (newValue < 0) color = app.view.redColor;
        else color = app.view.greenColor;

        StartCoroutine(CountTo(balanceHud.profitText, color, prevValue, newValue, _balanceModel.profitPerMonth.GetNameLocKey(),
            _balanceModel.profitPerMonth.GetPrefixLocKey(), _balanceModel.profitPerMonth.GetSuffixLocKey()));
    }

    void SetText(TextMeshProUGUI _text, Color _color, long _value, string _nameKey, string _prefixKey, string _suffixKey)
    {
        string locNameKey = LocalizedString(_nameKey);
        string locSuffixKey = LocalizedString(_suffixKey);
        string cash = MathUtil.LongToCashString(_value);
        string locCashSuffixKey = LocalizedString(MathUtil.LongToCashSuffixKey(_value));

        cash = "<color=" + app.view.StringColor(_color) + ">" + cash + "</color>";

        _text.text = locNameKey + ": "+  _prefixKey + cash + locCashSuffixKey + locSuffixKey;
    }

    string LocalizedString(string _value)
    {
        return app.controller.localization.GetLocalizedValue(_value);
    }

    IEnumerator CountTo(TextMeshProUGUI _text, Color _color, long _prevValue, long _newValue, string _name, string _prefix, string _suffix)
    {
        long _score;
        float duration = _balanceModel.GetCountDuration();
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            _score = (long)Mathf.Lerp(_prevValue, _newValue, progress);
            SetText(_text, _color, _score, _name, _prefix, _suffix);
            yield return null;
        }
        _score = _newValue;
        SetText(_text, _color, _newValue, _name, _prefix, _suffix);
    }
}
