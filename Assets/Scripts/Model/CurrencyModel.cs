
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class CurrencyModel
{
    public event Action<long, long> ON_AMOUNT_CHANGE;

    public string GetDefaultAmount()
    {
        return Config.defaultAmount;
    }
    public string GetID()
    {
        return Config.ID;
    }
    public int GetSpriteID()
    {
        return Config.spriteID;
    }
    //public string GetPlayerPrefsKey()
    //{
    //    return Config.playerPrefsKey;
    //}
    //public GameObject GetSkin()
    //{
    //    return Config.skin;
    //}

    public bool CanBuyWithCurrency(long _cost)
    {
        bool _canBuy = false;
        if (Amount >= _cost) _canBuy = true;
        return _canBuy;
    }

    [SerializeField]
    private long _amount;
    public long Amount
    {
        get => _amount;
        set
        {
            if (_amount == value) return;
            long _prevValue = _amount;

            if (value > 0) _amount = value;
            else _amount = 0;

            ON_AMOUNT_CHANGE?.Invoke(_prevValue, _amount);
            Save(_amount);

            //Debug.Log("CurrencyModel. Amount: " + GetID() + ". Prev: " + _prevValue + " New: " + _amount);
        }
    }

    [SerializeField]
    private CurrencyConfig _config;
    public CurrencyConfig Config
    {
        get => _config;
        set
        {
            if (_config == value) return;
            _config = value;
        }
    }

    public void Load()
    {
        Amount = Convert.ToInt64(PlayerPrefs.GetString(GetID(), GetDefaultAmount()));
        //Debug.Log("BalanceController. Load: " + GetID() + ". Amount: " + Amount);
    }

    void Save(long _value)
    {
        //Debug.Log("BalanceController. Save: " + GetID() + ". Amount: " + _value);
        PlayerPrefs.SetString(GetID(), Convert.ToString(_value));
    }
}