using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] private Transform _targetFollow;
    [SerializeField] private Vector3 _offsetFollow;
    [SerializeField] private float _speedFollow;
    private float speedFollow;
    
    private void Start()
    {
        speedFollow = _speedFollow * 0.1f;
    }

    void LateUpdate()
    {
        if (_targetFollow != null)
        {
            transform.position = Vector3.Lerp(transform.position, _targetFollow.position + _offsetFollow,
                Time.deltaTime * speedFollow);
        }
    }
}
