using System.Collections;
using TMPro;
using UnityEngine;
using Utilities;

public enum BalanceType
{
    Savings,
    Income,
    Expenses,
    Profit
}

public class BalanceView : MonoBehaviour
{
    private TextMeshProUGUI[] _texts;

    public void SetIcon(BalanceType type, bool isIcon, object text)
    {
    }

    public void SetText(BalanceType type, bool isIcon, object text)
    {
        GetText(type, isIcon).text = text.ToString();
    }

    private TextMeshProUGUI GetText(BalanceType type, bool isIcon)
    {
        int index = (isIcon) ? 1 : 2;
        index *= (int)type;
        return _texts[index];
    }

    public void OnSavingsChange(long prevValue, long newValue)
    {
        //StartCoroutine(CountTo(balanceHud.savingsText, balanceHud.savingsIconText, prevValue, newValue, _balanceModel.savings.GetSuffix()));
    }

    public void OnIncomePerMonthChange(long prevValue, long newValue)
    {
        //StartCoroutine(CountTo(GetText(BalanceType.Income, false), GetText(BalanceType.Income, true), prevValue, newValue, _balanceModel.incomePerMonth.GetSuffix()));
    }
    public void OnExpensesPerMonthChange(long prevValue, long newValue)
    {
        //StartCoroutine(CountTo(balanceHud.expensesText, balanceHud.expensesIconText, prevValue, newValue, _balanceModel.expensesPerMonth.GetSuffix()));
    }
    public void OnProfitChange(long prevValue, long newValue)
    {
        //StartCoroutine(CountTo(balanceHud.profitText, balanceHud.profitIconText, prevValue, newValue, _balanceModel.profitPerMonth.GetSuffix()));
    }

    IEnumerator CountTo(TextMeshProUGUI text, TextMeshProUGUI icon, long prevValue, long newValue, string suffix)
    {
        long _score;
        float duration = 0.0f;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            _score = (long)Mathf.Lerp(prevValue, newValue, progress);
            SetText(text, icon, _score, suffix);
            yield return null;
        }
        _score = newValue;
        SetText(text, icon, newValue, suffix);
    }

    void SetText(TextMeshProUGUI _text, TextMeshProUGUI _icon, long _value, string _suffix)
    {
        _text.text = MathUtil.LongToString(_value, "", _suffix);
    }

    void SetIcon(TextMeshProUGUI _text, int _ID)
    {
        _text.text = "<sprite=" + _ID + ">";
    }
}
