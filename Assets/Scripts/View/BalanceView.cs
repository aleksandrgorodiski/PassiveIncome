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
        _balanceModel.cashModel.ON_AMOUNT_CHANGE += OnCashChange;
    }

    void Start()
    {
        SetText(balanceHud.cashText, balanceHud.cashIconText, _balanceModel.cashModel.Amount);
        SetIcon(balanceHud.cashIconText, _balanceModel.cashModel.GetSpriteID());
    }

    private void OnDestroy()
    {
        _balanceModel.cashModel.ON_AMOUNT_CHANGE -= OnCashChange;
    }

    void OnCashChange(ulong prevValue, ulong newValue)
    {
        StartCoroutine(CountTo(balanceHud.cashText, balanceHud.cashIconText, prevValue, newValue));
    }

    void SetText(TextMeshProUGUI _text, TextMeshProUGUI _icon, ulong value)
    {
        _text.text = MathUtil.UlongToString(value, "");
    }

    void SetIcon(TextMeshProUGUI _text, int _ID)
    {
        _text.text = "<sprite=" + _ID + ">";
    }

    IEnumerator CountTo(TextMeshProUGUI text, TextMeshProUGUI iconText, ulong prevValue, ulong newValue)
    {
        ulong start = prevValue;
        ulong score;
        float duration = 0.25f;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            score = (ulong)Mathf.Lerp(start, newValue, progress);
            SetText(text, iconText, score);
            yield return null;
        }
        score = newValue;
        SetText(text, iconText, score);
    }
}
