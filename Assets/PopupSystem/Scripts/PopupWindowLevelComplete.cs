using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupWindowLevelComplete : PopupWindowBase
{
    [SerializeField]
    private Button _nextLevelButton;
    [SerializeField]
    private TextMeshProUGUI _nextLevelButtonText;

    public override void OnShow()
    {
        base.OnShow();

        _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        SetButtonText();
    }

    void SetButtonText()
    {
        _nextLevelButtonText.text = "Next Level";
    }

    void OnNextLevelButtonClick()
    {
        //app.controller.NextLevel();
    }

    protected override void PlayShowAnimation(Action callback)
    {
        //StartCoroutine(CoroutineIntroAnimation());
    }

    float _time;
    public float duration = 1f;
    public float _startScale = 0.5f;

    IEnumerator CoroutineIntroAnimation()
    {
        float _scale = _startScale;
        _rect.localScale = new Vector3(_scale, _scale, _scale);

        _time = 0f;
        while (_time < duration)
        {
            _time += Time.fixedDeltaTime;
            Debug.Log(_time);
            //_scale = Easing.EaseOutBack(_startScale, duration, _time);
            _scale = 1f;

            _rect.localScale = new Vector3(_scale, _scale, _scale);
            yield return null;
        }
    }
}
