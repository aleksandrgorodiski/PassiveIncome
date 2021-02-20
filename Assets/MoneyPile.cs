using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPile : MonoBehaviour
{
    public int cashOnStart;
    public int piecesCountX = 5;
    public int piecesCountZ = 5;
    public float pieceSizeX = 1f;
    public float pieceSizeY = 1f;
    public float pieceSizeZ = 1f;
    public float offsetX = 0.1f;
    public float offsetY = 0.1f;
    public float offsetZ = 0.1f;
    public GameObject packPrefab;
    //public List<Vector3> _places;
    public List<GameObject> moneyPacks = new List<GameObject>();


    private void Start()
    {
        CashOnStart();
    }

    Vector3 FirstPlacePos()
    {
        float _value = ((piecesCountX * pieceSizeX) * 0.5f) - (pieceSizeX * 0.5f);
        return new Vector3(-_value, 0f, 0f);
    }

    void CashOnStart()
    {
        for (int i = 0; i < cashOnStart; i++)
        {
            AddCash();
        }
    }

    public void AddCash()
    {
        int _moneyCount = moneyPacks.Count;
        GameObject _pack = Instantiate(packPrefab);
        _pack.transform.position = PlacePosition(_moneyCount);
        moneyPacks.Add(_pack);
    }

    public void RemoveCash()
    {
        int _last = moneyPacks.Count;
        if (_last > 0)
        {
            Destroy(moneyPacks[_last - 1]);
            moneyPacks.Remove(moneyPacks[_last - 1]);
        }
    }

    Vector3 PlacePosition(int _piece)
    {
        _piece++;
        //_places.Clear();
        Vector3 _posOut = Vector3.zero;
        float _directionX = pieceSizeX;
        int _piecesInFloor = piecesCountX * piecesCountZ;
        float _xPos = 0f, _yPos = 0f, _zPos = 0f;
        Vector3 _position = FirstPlacePos();

        for (int i = 0; i < _piece; i++)
        {
            if (i != 0 && i % piecesCountX == 0)
            {
                // начало нового ряда
                _zPos = _zPos + pieceSizeZ;
                _xPos = _xPos - _directionX;
                _directionX = -_directionX;
            }
            else
            {
                _zPos = 0f;
                if (i == 0) _xPos = 0f;
                else _xPos = _directionX;
            }
            _yPos = 0f;
            if (i != 0 && i % _piecesInFloor == 0)
            {
                //Debug.LogError("Next Floor");
                _yPos = _yPos + pieceSizeY;
                
                _position.x = FirstPlacePos().x;
                _position.z = FirstPlacePos().z;

                _zPos = 0f;
                if (i == 0) _xPos = 0f;
                else _xPos = 0f;
                _directionX = pieceSizeX;
            }

            _position = _position + new Vector3(_xPos, _yPos, _zPos);
            _posOut = new Vector3(_position.x + Random.Range(-offsetX, offsetX), _position.y + Random.Range(-offsetY, offsetY), _position.z + Random.Range(-offsetZ, offsetZ));
            //Instantiate(packPrefab).transform.position = _posOut;
            //_places.Add(_posOut);
            //Debug.LogError(_posOut);
        }
        return _posOut;
    }




















    //public void Places()
    //{
    //    _places.Clear();

    //    float _direction = 1f;

    //    float _xPos = 0f, _yPos = 0f, _zPos = 0f, _Zdirection = pieceSizeZ;
    //    Vector3 _position = FirstPlacePos();

    //    for (int i = 0; i < pieces; i++)
    //    {
    //        if (i != 0 && i % piecesInRow == 0)
    //        {
    //            _zPos = _zPos + _Zdirection;
    //            _xPos = _xPos - _direction;
    //            _direction = -_direction;
    //        }
    //        else
    //        {
    //            _zPos = 0f;
    //            if (i == 0) _xPos = 0f;
    //            else _xPos = _direction;
    //        }
    //        _yPos = 0f;
    //        if (i != 0 && i % piecesInFloor == 0)
    //        {
    //            Debug.LogError("Next Floor");
    //            _yPos = _yPos + pieceSizeY;
    //            _position.x = 0f;
    //            _position.z = 0f;
    //            _xPos = FirstPlacePos().x;
    //            _zPos = FirstPlacePos().z;
    //        }

    //        _position = _position + new Vector3(_xPos, _yPos, _zPos);
    //        Vector3 _posOut = new Vector3(_position.x + Random.Range(-unitOffsetX, unitOffsetX), _position.y, _position.z + Random.Range(-unitOffsetZ, unitOffsetZ));
    //        Instantiate(packPrefab).transform.position = _posOut;
    //        _places.Add(_posOut);
    //    }
    //}
}
