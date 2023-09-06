using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed;
    
    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.Y_Axis != 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * InputManager.Instance.Y_Axis * _speed);
        }

        if (InputManager.Instance.X_Axis != 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * InputManager.Instance.X_Axis * _speed);
        }
    }
}
