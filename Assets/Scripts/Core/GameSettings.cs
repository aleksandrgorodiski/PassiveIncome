using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : GameElement
{
    [Header("Target Frame Rate")]
    public int targetFrameRate = 60;

    private void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
    }

}
