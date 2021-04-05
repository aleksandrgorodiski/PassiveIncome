using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameView : GameElement
{
    public GameHud gameHud;


    public GameModel _gameModel
    {
        get => app.model;
    }
    private void Start()
    {

        _gameModel.ON_MONTH_CHANGE += SetDateText;

        SetDateText();
    }

    void SetDateText()
    {
        string _month = app.controller.monthList[_gameModel.CurrentMonth];
        string _year = _gameModel.CurrentYear.ToString();

        gameHud.dateText.text = _month + ", " + _year;
    }

    public void SetDateBar(float _value)
    {
        gameHud.dateBar.fillAmount = _value;
    }





}