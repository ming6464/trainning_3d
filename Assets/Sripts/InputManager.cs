using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance
    {
        get => _instance;
    }

    public float X_Axis;
    public float Y_Axis;

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }

    private void Update()
    {
        X_Axis = Input.GetAxis("Horizontal");
        Y_Axis = Input.GetAxis("Vertical");
    }
}
