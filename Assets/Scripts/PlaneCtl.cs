using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCtl : MonoBehaviour
{
    [SerializeField] private float _speedFly;
    
    private float x;
    

    private void Update()
    {
        if (InputManager.Instance.Ver_Axis > 0)
        {
            transform.Translate(Vector3.forward * _speedFly * Time.deltaTime);
        }
        
        var inputX = Input.GetAxis("Mouse X");
        x += inputX * 5;
        x = Mathf.Repeat(x, 360);
        Vector3 vtRotate = new Vector3(0f, x, 0f);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(vtRotate), Time.deltaTime * 5);
        
    }
}
