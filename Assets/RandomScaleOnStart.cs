using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScaleOnStart : MonoBehaviour
{
    void Start()
    {
        Vector3 _scale = transform.localScale;
        if (Random.Range(0, 2) == 0) transform.localScale = new Vector3(_scale.x, -_scale.y, _scale.z);
    }
}
