using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : GameElement
{
    public Transform positionIn;
    private Vector3 positionStart;
    public float moveSpeed;
    public float rotateSpeed;
    public float moveTime;
    public float rotateTime;
    public float waitTime;
    public GameObject cashPrefab;
    public Transform cashStartPos;
    public Transform cashEndPos;
    public Animator anim;

    void PlayAnimation(string clip, float time)
    {
        anim.Play(clip, 0, time);
    }

    private void OnAmountChanged(long arg1, long arg2)
    {
        StartCoroutine(MoveIn(positionIn.position));
        StartCoroutine(RotateIn(positionIn.position));
    }

    void Start()
    {
        app.model.balanceModel.savings.ON_AMOUNT_CHANGE += OnAmountChanged;
        positionStart = transform.position;
    }

    IEnumerator MoveIn(Vector3 _newPos)
    {
        PlayAnimation("Walk", 0f);

        Vector3 _startPosition = transform.position;
        float _t = 0.0f;
        while (_t < moveTime)
        {
            _t += Time.deltaTime;
            transform.position = Vector3.Lerp(_startPosition, _newPos, _t / moveTime);
            yield return null;
        }

        PlayAnimation("Idle", Random.Range(0f, 1f));
        FireCash();

        yield return new WaitForSeconds(waitTime);
        StartCoroutine(MoveOut(positionStart));
    }

    IEnumerator MoveOut(Vector3 _newPos)
    {
        PlayAnimation("Walk", 0f);

        Vector3 _startPosition = transform.position;
        float _t = 0.0f;
        while (_t < moveTime)
        {
            _t += Time.deltaTime;
            transform.position = Vector3.Lerp(_startPosition, _newPos, _t / moveTime);
            yield return null;
        }
    }

    IEnumerator RotateIn(Vector3 _newRot)
    {
        var targetDirection = _newRot - transform.position;
        targetDirection.y = 0f;
        var targetRotation = Quaternion.LookRotation(targetDirection);
        float _t = 0.0f;
        while (_t < moveTime)
        {
            _t += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _t / rotateTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(RotateOut(positionStart));
    }

    IEnumerator RotateOut(Vector3 _newRot)
    {
        var targetDirection = _newRot - transform.position;
        targetDirection.y = 0f;
        var targetRotation = Quaternion.LookRotation(targetDirection);
        float _t = 0.0f;
        while (_t < moveTime)
        {
            _t += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _t / rotateTime);
            yield return null;
        }
    }

    void FireCash()
    {
        GameObject _cash = Instantiate(cashPrefab);
        //_cash.transform.position = cashStartPos.position;
        _cash.GetComponent<ParabolaAnimation>().FireCash(cashEndPos, cashStartPos.position);
    }


}
