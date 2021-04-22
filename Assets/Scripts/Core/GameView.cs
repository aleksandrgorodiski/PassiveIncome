using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameView : GameElement
{
    public Color greenColor;
    public Color redColor;
    public Color yellowColor;

    public GameHud gameHud;

    public GameModel _gameModel
    {
        get => app.model;
    }

    private void Start()
    {
        CreateListAllMonth();
        _gameModel.ON_DATE_CHANGE += SetDateText;
        SetDateText();
    }

    void SetDateText()
    {
        string _month = monthList[_gameModel.CurrentMonth - 1];
        string _year = _gameModel.CurrentYear.ToString();
        gameHud.dateText.text = app.controller.localization.GetLocalizedValue("date") + ": "+ "<color=" + StringColor(yellowColor) + ">" + _month + ", " + _year + "</color>";
    }

    public string StringColor(Color color)
    {
        return "#" + ColorUtility.ToHtmlStringRGBA(color);
    }

    public void SetDateBar(float _value)
    {
        gameHud.dateBar.fillAmount = _value;
    }

    public List<string> monthList = new List<string>();
    void CreateListAllMonth()
    {
        CultureInfo languageCode = new CultureInfo(app.controller.localization.GetLocalizedValue("language_code"));
        for (int i = 0; i < 12; i++)
        {
            string _value = languageCode.DateTimeFormat.MonthNames[i];
            monthList.Add(_value);
            //Debug.LogError(_value);
        }
    }
}