using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    private Vector3 posChuotPrevious;
    private Vector3 currentPosChuot;
    public Vector3 hieuPos;
    public Quaternion pos;
    private Quaternion _pos;
    public Vector3 pos2;
    private Vector3 _pos2;
    public float rotationSpeed;
    public float x = 0f;
    public float y = 0f;
    public float inputX;
    public float inputY;
    public bool _isGround;
    public bool isGround
    {
        get => _isGround;
        set => _isGround = value;
    }

    void Start()
    {
        //set vị trí chuột giữa màn hình
        // posGiuaManHinh = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.width / 2, 0));
        // Cursor.visible = true;
        // Cursor.lockState = CursorLockMode.None;
        //posChuotPrevious = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //posChuotPrevious = Input.mousePosition;
        // pos = Quaternion.Euler(0, 90, 0);
        // transform.Rotate(pos.eulerAngles);
        // Debug.Log(pos.eulerAngles);
        // Quaternion = transform.rotation;
        // Debug.Log(Quaternion.eulerAngles);
        
    }

    private void Rotate()
    {
        inputX = Input.GetAxis("Mouse X");
        inputY = Input.GetAxis("Mouse Y");
        x +=  inputX * 5;
        x = Mathf.Repeat(x, 360);

        y += inputY * 5;

        var miny = 0;
        
        if (!isGround)
        {
            miny = -90;
        }
        
        y = Mathf.Clamp(y, miny, 90) * -1;
        y = Mathf.Floor(y);
        
        //transform.localRotation = Quaternion.Slerp(transform.localRotation,Quaternion.Euler(y,x,0),5 * Time.deltaTime );
        transform.localRotation = Quaternion.Slerp(transform.localRotation,Quaternion.Euler(0,x,0),5 * Time.deltaTime );
    }

    // private void OnValidate()
    // {
    //     if (pos != _pos)
    //     {
    //         transform.localRotation = pos;
    //         _pos = pos;
    //     }else if (pos2 != _pos2)
    //     {
    //         transform.localRotation = Quaternion.Euler(pos2);
    //         _pos2 = pos2;
    //     }
    //     
    // }

    private void FixedUpdate()
    {
        // currentPosChuot = Input.mousePosition;
        // hieuPos = currentPosChuot - posChuotPrevious;
        //
        // if (InputManager.Instance.Ver_Axis != 0)
        // {
        //     transform.Translate(Vector3.forward * InputManager.Instance.Ver_Axis * 5 * Time.deltaTime);
        // }
        // transform.Rotate(Vector3.right,hieuPos.y);
        //  transform.Rotate(Vector3.up,hieuPos.x);
        //  posChuotPrevious = currentPosChuot;
        //  pos = transform.localRotation;
        //  pos2 = pos.eulerAngles;
    }

    void Update()
    {
        // // Lấy vị trí hiện tại của chuột trên màn hình
        // Vector3 mousePosition = Input.mousePosition;
        //
        // // Tính toán vector từ vị trí hiện tại của nhân vật đến vị trí của chuột
        // Vector3 characterToMouse = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        // characterToMouse.z = 0f; // Đảm bảo rằng z = 0 để tránh xoay quanh trục z
        //
        // // Tính toán góc giữa vector characterToMouse và trục Vector3.up
        // float angle = Mathf.Atan2(characterToMouse.y, characterToMouse.x) * Mathf.Rad2Deg;
        //
        // // Tạo một quaternion xoay góc angle quanh trục Vector3.forward (trục z)
        // Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        //
        // // Sử dụng Lerp để mịn hóa sự xoay
        // transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        Rotate();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log( "exit: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log( "stay: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
