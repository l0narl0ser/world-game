using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("SetInInspector")]
    public float speed = 6.0f;
    public float gravity = -9.8f;

    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, gravity, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement = transform.TransformDirection(movement * Time.deltaTime);
        _characterController.Move(movement);
    }
}
