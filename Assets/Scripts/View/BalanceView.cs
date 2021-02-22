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

        SetText(balanceHud.savingsText, balanceHud.savingsIconText, _balanceModel.savings.Amount);
        SetText(balanceHud.incomeText, balanceHud.incomeIconText, _balanceModel.incomePerMonth.Amount);
        SetText(balanceHud.expensesText, balanceHud.expensesIconText, _balanceModel.expensesPerMonth.Amount);
        SetText(balanceHud.profitText, balanceHud.profitIconText, _balanceModel.profit.Amount);
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
        StartCoroutine(CountTo(balanceHud.savingsText, balanceHud.savingsIconText, prevValue, newValue));
    }
    void OnIncomePerMonthChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.incomeText, balanceHud.incomeIconText, prevValue, newValue));
    }
    void OnExpensesPerMonthChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.expensesText, balanceHud.expensesIconText, prevValue, newValue));
    }
    void OnProfitChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.profitText, balanceHud.profitIconText, prevValue, newValue));
    }

    void SetText(TextMeshProUGUI _text, TextMeshProUGUI _icon, long value)
    {
        _text.text = MathUtil.LongToString(value, "");
    }

    void SetIcon(TextMeshProUGUI _text, int _ID)
    {
        _text.text = "<sprite=" + _ID + ">";
    }

    IEnumerator CountTo(TextMeshProUGUI text, TextMeshProUGUI iconText, long prevValue, long newValue)
    {
        long start = prevValue;
        long score;
        float duration = 0.2f;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            score = (long)Mathf.Lerp(start, newValue, progress);
            SetText(text, iconText, score);
            yield return null;
        }
        score = newValue;
        SetText(text, iconText, score);
    }
}
