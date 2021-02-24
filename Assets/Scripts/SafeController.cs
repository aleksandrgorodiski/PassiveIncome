using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeController : MonoBehaviour
{
    public Transform doorTransform;

    public float spinDuration = 1f;
    public float deltaAngle;

    private void Start()
    {
        OpenClose();
    }

    public void OpenClose()
    {
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        yield return new WaitForEndOfFrame();

        Vector3 _startPosition = doorTransform.eulerAngles;
        Vector3 _newRot = new Vector3(doorTransform.eulerAngles.x, GetAngle(), doorTransform.eulerAngles.z);

        float _t = 0.0f;
        while (_t < spinDuration)
        {
            _t += Time.deltaTime;
            doorTransform.eulerAngles = Vector3.Lerp(_startPosition, _newRot, _t / spinDuration);
            yield return null;
        }
    }

    bool isOpen;

    float GetAngle()
    {
        float _angle = 0f;
        if (isOpen)
        {
            isOpen = false;
            _angle = 0f;
        }
        else
        {
            isOpen = true;
            _angle = deltaAngle;
        }
        return _angle;
    }
}
