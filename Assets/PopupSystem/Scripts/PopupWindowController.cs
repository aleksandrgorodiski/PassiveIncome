using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWindowController : MonoBehaviour
{
    public PopupWindowConfig popupWindowConfig;
    public GameObject activePopup;

    public void ShowWindow(string _ID)
    {
        if (activePopup) return;

        foreach (GameObject _gameObject in popupWindowConfig.windowPrefabs)
        {
            PopupWindowBase _popup = _gameObject.GetComponent<PopupWindowBase>();
            if (_popup.GetWindowID() == _ID)
            {
                //Debug.Log("ID found: " +_ID);
                GameObject _out = Instantiate(_gameObject, transform);
                activePopup = _out;
                break;
            }
            Debug.LogError("ID not found: " + _ID);
        }
    }

    public void CloseActiveWindow()
    {
        if (activePopup) Destroy(activePopup);
    }
}

