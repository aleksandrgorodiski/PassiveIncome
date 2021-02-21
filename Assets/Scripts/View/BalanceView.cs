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
        _balanceModel.savingsModel.ON_AMOUNT_CHANGE += OnCashChange;
    }

    void Start()
    {
        SetText(balanceHud.cashText, balanceHud.cashIconText, _balanceModel.savingsModel.Amount);
        SetIcon(balanceHud.cashIconText, _balanceModel.savingsModel.GetSpriteID());
    }

    private void Update()
    {

    }

    private void OnDestroy()
    {
        _balanceModel.savingsModel.ON_AMOUNT_CHANGE -= OnCashChange;
    }

    void OnCashChange(long prevValue, long newValue)
    {
        StartCoroutine(CountTo(balanceHud.cashText, balanceHud.cashIconText, prevValue, newValue));
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
