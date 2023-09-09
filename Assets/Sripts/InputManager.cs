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

    public float Hor_Axis;
    public float Ver_Axis;

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }

    private void Update()
    {
        Hor_Axis = Input.GetAxis("Horizontal");
        Ver_Axis = Input.GetAxis("Vertical");
    }
}
