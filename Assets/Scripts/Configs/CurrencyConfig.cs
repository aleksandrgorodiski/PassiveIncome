using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "config/currency")]
public class CurrencyConfig : ScriptableObject
{
    public string ID;
    public int spriteID;
    public string localizationKey;
    public string defaultAmount;
    public string suffix;
}


