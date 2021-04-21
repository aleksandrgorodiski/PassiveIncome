using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "config/currency")]
public class CurrencyConfig : ScriptableObject
{
    public string ID;
    public string nameLocKey;
    public string defaultAmount;
    public string prefixLocKey;
    public string suffixLocKey;
}


