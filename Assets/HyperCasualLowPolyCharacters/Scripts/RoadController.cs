using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public float posZ = 16;

    void FixedUpdate()
    {

        transform.position -= transform.forward * Time.fixedDeltaTime * Speed();
        if (transform.position.z <= -posZ)
        {
            float _sdsdsd = posZ * 2;
            transform.position += new Vector3(0f, 0f, _sdsdsd);
        }
    }

    float Speed()
    {
        float _speed = EnvSettings.instance.speed;
        if (EnvSettings.instance.freeze) _speed = 0f;
        return _speed;
    }
}
