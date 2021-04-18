using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaAnimation : GameElement
{
    protected float Animation;
    Vector3 _startPosition;
    public float _flightTime = 1f;
    public float _height = 2f;
    public float _rotSpeed = 500f;
    private int _rotDirection;
    private Transform _parcelDestination;

    public void FireCash(Transform parcelDestination, Vector3 value)
    {
        _startPosition = value;
        _parcelDestination = parcelDestination;
        _rotDirection = GetDirection();
    }

    int GetDirection()
    {
        return Random.Range(0, 2) * 2 - 1;
    }

    void Update()
    {
        if(_parcelDestination != null)
        {
            Animation += Time.deltaTime;
            if (Animation > _flightTime)
            {
                Destroy(gameObject);
            }

            Animation = Animation % _flightTime;
            transform.position = MathParabola.Parabola(_startPosition, _parcelDestination.position, _height, Animation / _flightTime);
            transform.Rotate(Vector3.up * _rotSpeed * _rotDirection * Time.deltaTime, Space.Self);
        }
    }
}
