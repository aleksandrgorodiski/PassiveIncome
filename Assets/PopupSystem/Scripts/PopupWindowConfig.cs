using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "config/popup_windows")]
public class PopupWindowConfig : ScriptableObject
{
    public List<GameObject> windowPrefabs;
}

