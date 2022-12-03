using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        AxesXY = 0,
        AxesX = 1,

        AxesY= 2
    }

    [Header("SetInInspector")]
    public RotationAxes axes = RotationAxes.AxesXY;
    public float rotationSpeed = 5.0f;

    [Header("SetDynamically")]
    public float minimalVert = 45.0f;
    private float _rotationX = 0f;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
        {
            body.freezeRotation = true;
        }
    }

    private void Update()
    {
        RotateGo();
    }
    private void RotateGo()
    {
        if (axes == RotationAxes.AxesX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed,0);
        }
        else if(axes == RotationAxes.AxesY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -minimalVert, minimalVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
            _rotationX = Mathf.Clamp(_rotationX, -minimalVert, minimalVert);
            float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X")*rotationSpeed;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
