using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvSettings : MonoBehaviour
{
    public static EnvSettings instance;
    public float speed = 8f;
    public bool freeze;

    private void Awake()
    {
        instance = this;
    }
}
