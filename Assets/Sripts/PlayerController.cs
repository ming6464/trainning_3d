using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private WheelCollider _topRight;
    [SerializeField] private WheelCollider _topLeft;
    [SerializeField] private WheelCollider _bottomRight;
    [SerializeField] private WheelCollider _bottomLeft;

    [SerializeField] private float _breakingForce = 300f;
    [SerializeField] private float _acceleration = 500f;
    [SerializeField] private float _turnAngle;
    private float currentAccelerantion;
    private float currentBreakingForce;
    private float currentTurnAngle;

    private void FixedUpdate()
    {
        currentAccelerantion = _acceleration * InputManager.Instance.Ver_Axis;
        if (Input.GetKey(KeyCode.Space))
        {
            
        }
        else currentBreakingForce = 0f;

        _topLeft.brakeTorque = 0;
        _topRight.brakeTorque = 0;
        _bottomRight.brakeTorque = 0;
        _bottomLeft.brakeTorque = 0;
        
        if (Input.mousePresent)
        {
            currentBreakingForce = _breakingForce;
            if (Input.GetMouseButton(0))
            {
                _topLeft.brakeTorque = currentBreakingForce;
                _topRight.brakeTorque = currentBreakingForce;
            }
            if (Input.GetMouseButton(1))
            {
                _bottomRight.brakeTorque = currentBreakingForce;
                _bottomLeft.brakeTorque = currentBreakingForce;
            }
        }

        if (InputManager.Instance.Ver_Axis != 0)
        {
            if (InputManager.Instance.Ver_Axis > 0)
            {
                _topRight.motorTorque = currentAccelerantion;
                _topLeft.motorTorque = currentAccelerantion;
            }
            else
            {
                _bottomRight.motorTorque = currentAccelerantion;
                _bottomLeft.motorTorque = currentAccelerantion;
            }
        }
        currentTurnAngle = _turnAngle * InputManager.Instance.Hor_Axis;
        _topLeft.steerAngle = currentTurnAngle;
        _topRight.steerAngle = currentTurnAngle;

        UpdateWheel(_topLeft, _topLeft.transform);
        UpdateWheel(_topRight, _topRight.transform);
        UpdateWheel(_bottomLeft, _bottomLeft.transform);
        UpdateWheel(_bottomRight, _bottomRight.transform);
    }

    private void UpdateWheel(WheelCollider col, Transform tran)
    {
        col.GetWorldPose(out var pos,out var rotation);
        //tran.position = pos;
        tran.rotation = rotation;
    }
}
