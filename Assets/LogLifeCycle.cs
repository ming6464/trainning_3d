using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogLifeCycle : MonoBehaviour
{

    private string nameObj => transform.name;
    
    private void Awake()
    {
        Debug.Log(nameObj + "  go on awake");
    }

    private void OnEnable()
    {
        Debug.Log(nameObj + "  go on OnEnable");
    }

    private void Start()
    {
        Debug.Log(nameObj + "  go on Start");
    }

    private void Reset()
    {
        Debug.Log(nameObj + "  go on Reset");
    }

    private void FixedUpdate()
    {
        Debug.Log(nameObj + "  go on FixedUpdate");
    }
}
