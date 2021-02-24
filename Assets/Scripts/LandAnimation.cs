using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LandAnimation : MonoBehaviour
{
    public float positionY = 1f;
    public Vector3 _scaleEnd = new Vector3(1f, 0.4f, 1f);
    public float _speedTransform = 0.2f;
    public float _speedScaleIn = 0.1f;
    public float _speedScaleOut = 3f;
    public float _amplitudeScaleOut = 1f;

    private Vector3 _positionOnBirth;

    void Start()
    {
        //Debug.LogError("LandAnimation. Start. " + transform.position.y);

        GetBirthPosition();
        SetPosition();

        MoveDownAnimation();
    }

    void GetBirthPosition()
    {
        _positionOnBirth = transform.position;
    }

    void SetPosition()
    {
        transform.position += Vector3.up * positionY;
    }

    void MoveDownAnimation()
    {
        transform.DOKill();
        transform.DOMove(_positionOnBirth, _speedTransform).SetEase(Ease.InQuad).OnComplete(() => 
        {
            ScaleInAnimation();
        });
    }

    void ScaleInAnimation()
    {
        transform.DOKill();
        transform.DOScale(_scaleEnd, _speedScaleIn).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            ScaleOutAnimation();
        });
    }

    void ScaleOutAnimation()
    {
        transform.DOKill();
        transform.DOScale(Vector3.one, _speedScaleOut).SetEase(Ease.OutBack, _amplitudeScaleOut).OnComplete(() => {});
    }
}
