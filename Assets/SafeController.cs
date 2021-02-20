using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeController : MonoBehaviour
{
    float _distanceX;


    public float spinDuration = 1f;
    public float deltaAngle;


    public void OpenClose()
    {
        //Vector3 _position = new Vector3(GetDistance(), 0f, transform.position.z);
        //StartCoroutine(CoroutineChangeSide(_position));

        StartCoroutine(Spin());

    }


    IEnumerator Spin()
    {
        yield return new WaitForEndOfFrame();

        Vector3 _startPosition = transform.eulerAngles;

        Vector3 _newRot = new Vector3(transform.eulerAngles.x, GetAngle(), transform.eulerAngles.z);

        //Debug.LogError(_newRot.y);

        float _t = 0.0f;

        while (_t < spinDuration)
        {
            _t += Time.deltaTime;
            transform.eulerAngles = Vector3.Lerp(_startPosition, _newRot, _t / spinDuration);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation, _newRot, _t / spinDuration);

            yield return null;
        }
    }

    bool isOpen;
    public float _speed = 5f;

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

    //IEnumerator SpinA()
    //{
    //    yield return new WaitForEndOfFrame();

    //    Vector3 _startRotation = transform.eulerAngles;
    //    float _endRotation = GetAngle();

    //    Debug.LogError(_endRotation);

    //    float _t = 0.0f;

    //    //float _direction = 1f;
    //    //if (transform.position.x > 0f) _direction = 1f;
    //    //else _direction = -1f;

    //    while (_t < spinDuration)
    //    {
    //        _t += Time.deltaTime;
    //        float yRotation = Mathf.Lerp(_startRotation.y, _endRotation, _t / spinDuration);

    //        Debug.Log(yRotation);

    //        transform.eulerAngles = new Vector3(_startRotation.x, yRotation, _startRotation.z);
    //        yield return null;
    //    }
    //}



}
