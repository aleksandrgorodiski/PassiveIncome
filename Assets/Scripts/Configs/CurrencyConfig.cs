using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "config/currency")]
public class CurrencyConfig : ScriptableObject
{
    public GameObject skin;

    public string ID;
    public int spriteID;
    public string localizationKey;
    public string playerPrefsKey;
    public string defaultAmount;
    [Header("Pieces to be spawned")]
    public int pieces;
    [Header("Nominal per piece")]
    public int nominal;
    public bool destroyByTime;
}


