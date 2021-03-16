using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    public bool isRotate;
    public Button IsRotateCameraButton;

    void Start()
    {
        IsRotateCameraButton.onClick.AddListener(ChangeIsRotate);
    }

    void FixedUpdate()
    {
        if (isRotate)
        {
            Vector3 _newRot = new Vector3(0f, speed * Time.fixedDeltaTime, 0f);
            transform.Rotate(_newRot, Space.World);
        }
    }

    void ChangeIsRotate()
    {
        if (isRotate) isRotate = false;
        else isRotate = true;
    }

    void ChangeSpeed()
    {
        speed = speed * -1;
    }
}
