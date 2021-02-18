using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private GameObject helper;

    void Start()
    {
        helper = new GameObject();
        helper.transform.parent = transform;
        helper.transform.localPosition = Vector3.zero;
        helper.transform.localRotation = Quaternion.identity;
        helper.name = "helper_" + name;
    }

    public void FireEffect(CurrencyConfig _config, int _pieces, Vector3 _effectPosition, Transform _objectToLookAt)
    {
        StartCoroutine(CoroutineInstantiateEffect(_config, _pieces, _effectPosition, _objectToLookAt));
    }

    private IEnumerator CoroutineInstantiateEffect(CurrencyConfig _config, int _pieces, Vector3 _effectPosition, Transform _objectToLookAt)
    {
        helper.transform.position = _effectPosition;
        helper.transform.LookAt(_objectToLookAt);
        helper.transform.eulerAngles = new Vector3(0f, helper.transform.eulerAngles.y, 0f);

        float _time = 0f;
        for (int i = 0; i < _pieces; i++)
        {
            yield return new WaitForSeconds(_time);
            SpawnPiece(_config);
            _time = 0.06f;
        }
    }

    void SpawnPiece(CurrencyConfig _config)
    {
        GameObject _item = Instantiate(_config.skin, helper.transform.position, Quaternion.identity);
        _item.transform.eulerAngles = new Vector3(GetRandomAngle(), GetRandomAngle(), GetRandomAngle());


        Rigidbody rb = _item.GetComponent<Rigidbody>();
        rb.drag = 0f;
        rb.useGravity = true;

        float _force = 15f;
        //float _right = Random.Range(-0.2f, 0.2f);
        float _right = 0f;
        float _up = Random.Range(0.8f, 1f);
        float _forward = 0f;

        Vector3 force = helper.transform.right * _right * _force
         + helper.transform.up * _up * _force
        + helper.transform.forward * _forward * _force;

        rb.AddForceAtPosition(force, transform.position, ForceMode.Impulse);

        if (_config.destroyByTime) Destroy(_item, 5f);
    }

    float GetRandomAngle()
    {
        return Random.Range(0f, 360f);
    }
}
