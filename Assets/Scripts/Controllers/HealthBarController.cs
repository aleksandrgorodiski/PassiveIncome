using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public sealed class HealthBarView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _txtHealthBar;

    public void SetHealthProgress(float value)
    {
        _txtHealthBar.text = (value * 100).ToString();
    }
}

public class HealthBarController
{
    private HealthBarView _view;

    public HealthBarController(HealthBarView view)
    {
        _view = view;
    }

    public void Update()
    {
        _view.SetHealthProgress(Time.time);
        _view.transform.LookAt(Camera.main.transform);
    }
}
