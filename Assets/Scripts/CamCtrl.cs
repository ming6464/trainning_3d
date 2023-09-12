using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamCtrl : MonoBehaviour
{
    private float y;
    
    private void LateUpdate()
    {
        y -= Input.GetAxis("Mouse Y")* 5;
        y = Mathf.Clamp(y, -24, 31);
        Vector3 vtRotate = new Vector3(y, 0f, 0f);
        var qua = Quaternion.Slerp(transform.localRotation,Quaternion.Euler(vtRotate), Time.deltaTime * 5 );
        transform.localRotation = qua;
    }
}
