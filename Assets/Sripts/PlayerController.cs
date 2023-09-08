using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate;
    
    // Update is called once per frame
    void Update()
    {
        if (InputManager.Instance.Y_Axis != 0)
        {
            var y = Time.deltaTime * InputManager.Instance.Y_Axis * _speed;
            transform.Translate(Vector3.forward * y);
            if (InputManager.Instance.X_Axis != 0)
            {
                transform.RotateAround(Vector3.up, Time.deltaTime * InputManager.Instance.X_Axis * _speedRotate);
                transform.Translate(Vector3.right * Mathf.Tan(transform.localRotation.y));
            }
        }

        
    }
}
