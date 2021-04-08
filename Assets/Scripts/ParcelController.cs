﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelController : GameElement
{
    protected float Animation;
    Vector3 _startPosition;
    private float _flightTime;
    private float _height;
    private float _rotSpeed;
    private int _rotDirection;
    private Transform _parcelDestination;

    void Start()
    {
        _flightTime = 0.7f;
        _height = 4f;
        _rotSpeed = 750f;
        _rotDirection = GetDirection();
    }

    public void FireCash(Transform parcelDestination)
    {
        _parcelDestination = parcelDestination;
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
