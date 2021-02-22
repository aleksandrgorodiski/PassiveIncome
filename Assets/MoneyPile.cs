using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoneyPile : GameElement
{
    public CurrencyModel currencyModel;

    public int piecesCountX = 5;
    public int piecesCountZ = 5;

    public float pieceSizeX = 1f;
    public float pieceSizeY = 1f;
    public float pieceSizeZ = 1f;

    public float offsetX = 0.1f;
    public float offsetY = 0.1f;
    public float offsetZ = 0.1f;

    public GameObject packPrefab;
    public List<GameObject> moneyPacks = new List<GameObject>();

    [Header("Длина единицы времени(сек)")]
    public float timeUnitLength;
    public float _time;

    [Header("Долларов в пачке")]
    public long dollarsInOnePack = 10000;

    [Header("Доходы")]
    public long incomePerMonth = 1000;

    [Header("Расходы")]
    public long expensesPerMonth = 1000;

    public float _packsCountFloat;
    public long _packsCount;
    public long _packsCountAbsolute;

    [Header("Текущий баланс")]
    public long _currentBalance;
    public long CurrentBalance
    {
        get => _currentBalance = Convert.ToInt64(PlayerPrefs.GetString(GetPlayerPrefsKey(), "0"));
        set
        {
            if (_currentBalance == value) return;
            _currentBalance = value;
            PlayerPrefs.SetString(GetPlayerPrefsKey(), Convert.ToString(_currentBalance));
            //Debug.Log("CurrencyModel. Amount: " + GetID() + ". Prev: " + _prevValue + " New: " + _amount);
        }
    }

    private void Start()
    {
        MoneyPackOnStart();
    }

    private void Update()
    {
        //_time += Time.deltaTime;
        //if (_time >= timeUnitLength)
        //{
        //    _time = 0f;
        //    long _lastMonthBalance = incomePerMonth - expensesPerMonth;
        //    app.model.balanceModel.savings.Amount += _lastMonthBalance;
        //    CurrentBalance += _lastMonthBalance;
        //    _packsCountFloat = (float)CurrentBalance / (float)dollarsInOnePack;
        //    _packsCount = (long)(_packsCountFloat);
        //    _packsCountAbsolute = (long)(Mathf.Abs(_packsCount));
        //    if (_packsCount != 0)
        //    {
        //        if (_packsCount > 0)
        //        {
        //            AddMoneyPack(_packsCountAbsolute);
        //        }
        //        else if (_packsCount < 0)
        //        {
        //            RemoveMoneyPack(_packsCountAbsolute);
        //        }
        //        CurrentBalance = CurrentBalance - (_packsCount * dollarsInOnePack);
        //        _packsCountFloat = 0f;
        //        _packsCount = 0;
        //        _packsCountAbsolute = 0;
        //    }
        //}
    }




    Vector3 FirstPlacePos()
    {
        float _value = ((piecesCountX * pieceSizeX) * 0.5f) - (pieceSizeX * 0.5f);
        return new Vector3(-_value, 0f, 0f);
    }

    void MoneyPackOnStart()
    {
        float _packsCountFloat = (float) app.model.balanceModel.savings.Amount / (float)dollarsInOnePack;
        Debug.LogError("Packs Count On Start: " + _packsCountFloat);

        long _packsCountLond = (long)(_packsCountFloat);
        Debug.LogError("Packs Count On Start: " + _packsCountLond);

        Debug.LogError("Current Balance On Start: " + CurrentBalance);

        AddMoneyPack(_packsCountLond);
    }



    public string GetPlayerPrefsKey()
    {
        return "CurrentBalance";
    }

    public void AddMoneyPack(long _count)
    {
        for (long i = 0; i < _count; i++)
        {
            int _moneyCount = moneyPacks.Count;
            GameObject _pack = Instantiate(packPrefab);
            _pack.transform.position = PlacePosition(_moneyCount);
            moneyPacks.Add(_pack);
        }
    }

    public void RemoveMoneyPack(long _count)
    {
        int _last = moneyPacks.Count;
        if (_last > 0)
        {
            Destroy(moneyPacks[_last - 1]);
            moneyPacks.Remove(moneyPacks[_last - 1]);
        }
    }

    Vector3 PlacePosition(int _piece)
    {
        _piece++;
        Vector3 _posOut = Vector3.zero;
        float _directionX = pieceSizeX;
        int _piecesInFloor = piecesCountX * piecesCountZ;
        float _xPos = 0f, _yPos = 0f, _zPos = 0f;
        Vector3 _position = FirstPlacePos();

        for (int i = 0; i < _piece; i++)
        {
            if (i != 0 && i % piecesCountX == 0)
            {
                // начало нового ряда
                _zPos = _zPos + pieceSizeZ;
                _xPos = _xPos - _directionX;
                _directionX = -_directionX;
            }
            else
            {
                _zPos = 0f;
                if (i == 0) _xPos = 0f;
                else _xPos = _directionX;
            }
            _yPos = 0f;
            if (i != 0 && i % _piecesInFloor == 0)
            {
                _yPos = _yPos + pieceSizeY;
                
                _position.x = FirstPlacePos().x;
                _position.z = FirstPlacePos().z;

                _zPos = 0f;
                _xPos = 0f;
                _directionX = pieceSizeX;
            }
            _position = _position + new Vector3(_xPos, _yPos, _zPos);
            _posOut = new Vector3(_position.x + Random.Range(-offsetX, offsetX), _position.y + Random.Range(-offsetY, offsetY), _position.z + Random.Range(-offsetZ, offsetZ));
        }
        return _posOut;
    }





    //public void TestTruncate()
    //{
    //    float[] numbers = { 1.499f, 1.999f, 2f, 2.15f, 2.55f };
    //    Debug.Log($"          value\ttruncate\tcast\tfloor\tceil");
    //    for (int i = 0; i < numbers.Length; i++)
    //    {
    //        float value = numbers[i];
    //        double truncate = Math.Truncate(value);
    //        int cast = (int)(value);
    //        int floor = Mathf.FloorToInt(value);
    //        int ceil = Mathf.CeilToInt(value);
    //        Debug.Log($"{i}   :   {value}     \t     {truncate}     \t     {cast}     \t     {floor}     \t     {ceil}");
    //    }
    //}
}
