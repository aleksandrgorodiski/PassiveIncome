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
        _balanceModel.savings.ON_AMOUNT_CHANGE += OnSavingsChange;
        _balanceModel.incomePerMonth.ON_AMOUNT_CHANGE += OnIncomePerMonthChange;
        _balanceModel.expensesPerMonth.ON_AMOUNT_CHANGE += OnExpensesPerMonthChange;
        _balanceModel.profit.ON_AMOUNT_CHANGE += OnProfitChange;
    }

    void Start()
    {
        SetIcon(balanceHud.savingsIconText, _balanceModel.savings.GetSpriteID());
        SetIcon(balanceHud.incomeIconText, _balanceModel.incomePerMonth.GetSpriteID());
        SetIcon(balanceHud.expensesIconText, _balanceModel.expensesPerMonth.GetSpriteID());
        SetIcon(balanceHud.profitIconText, _balanceModel.profit.GetSpriteID());

        SetText(balanceHud.savingsText, balanceHud.savingsIconText, _balanceModel.savings.Amount, _balanceModel.savings.GetSuffix());
        SetText(balanceHud.incomeText, balanceHud.incomeIconText, _balanceModel.incomePerMonth.Amount, _balanceModel.incomePerMonth.GetSuffix());
        SetText(balanceHud.expensesText, balanceHud.expensesIconText, _balanceModel.expensesPerMonth.Amount, _balanceModel.expensesPerMonth.GetSuffix());
        SetText(balanceHud.profitText, balanceHud.profitIconText, _balanceModel.profit.Amount, _balanceModel.profit.GetSuffix());
    }

    private void OnDestroy()
    {
        _balanceModel.savings.ON_AMOUNT_CHANGE -= OnSavingsChange;
        _balanceModel.incomePerMonth.ON_AMOUNT_CHANGE -= OnIncomePerMonthChange;
        _balanceModel.expensesPerMonth.ON_AMOUNT_CHANGE -= OnExpensesPerMonthChange;
        _balanceModel.profit.ON_AMOUNT_CHANGE -= OnProfitChange;
    }

    void OnSavingsChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.savingsText, balanceHud.savingsIconText, prevValue, newValue, _balanceModel.savings.GetSuffix()));
    }
    void OnIncomePerMonthChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.incomeText, balanceHud.incomeIconText, prevValue, newValue, _balanceModel.incomePerMonth.GetSuffix()));
    }
    void OnExpensesPerMonthChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.expensesText, balanceHud.expensesIconText, prevValue, newValue, _balanceModel.expensesPerMonth.GetSuffix()));
    }
    void OnProfitChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.profitText, balanceHud.profitIconText, prevValue, newValue, _balanceModel.profit.GetSuffix()));
    }

    void SetText(TextMeshProUGUI _text, TextMeshProUGUI _icon, long _value, string _suffix)
    {
        _text.text = MathUtil.LongToString(_value, "", _suffix);
    }

    void SetIcon(TextMeshProUGUI _text, int _ID)
    {
        _text.text = "<sprite=" + _ID + ">";
    }

    IEnumerator CountTo(TextMeshProUGUI _text, TextMeshProUGUI _icon, long _prevValue, long _newValue, string _suffix)
    {
        //long start = _prevValue;
        long _score;
        float duration = 0.0f;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            _score = (long)Mathf.Lerp(_prevValue, _newValue, progress);
            SetText(_text, _icon, _score, _suffix);
            yield return null;
        }
        _score = _newValue;
        SetText(_text, _icon, _newValue, _suffix);
    }
}
