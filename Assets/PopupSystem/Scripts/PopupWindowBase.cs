using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupWindowBase : GameElement
{
    // Start is called before the first frame update
    [SerializeField]
    private string _windowID;
    [SerializeField]
    public RectTransform _rect;

    public string GetWindowID()
    {
        return _windowID;
    }

    void Awake()
    {
        //Debug.LogError("Awake");
    }

    void Start()
    {
        //Debug.LogError("Start");
        OnShow();
    }

    public virtual void OnShow()
    {
        _rect = GetComponent<RectTransform>();
        PlayShowAnimation(null);
    }

    protected virtual void PlayShowAnimation(Action callback)
    {

    }

    protected virtual void PlayHideAnimation(Action callback)
    {

    }
}
