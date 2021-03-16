using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScaleRotation : MonoBehaviour
{
    public bool doScale;
    public bool doRotation;

    void Start()
    {
        if (doScale) DoScale();

        if (doRotation) DoRotation();
    }

    void DoScale()
    {
        float _scale = Random.Range(0.4f, 1f);
        transform.localScale = new Vector3(_scale, _scale, _scale);
    }

    void DoRotation()
    {
        float _angleY = Random.Range(0f, 360f);
        transform.localEulerAngles = new Vector3(0f, _angleY, 0f);
    }
}
