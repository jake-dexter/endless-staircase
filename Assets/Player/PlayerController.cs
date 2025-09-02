using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 3f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform groundCheck;

    private float gravity = -9.81f;

    private Rigidbody rb;
    private CharacterController controller;
    private GameInput gameInput;

    private float xRotation;
    private float mouseX;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        gameInput = FindObjectOfType<GameInput>();
    }

    private void Update()
    {
        ProcessKeyboardMovement();
        ProcessMouseMovement();
        ApplyGravity();
    }

    private void ProcessKeyboardMovement()
    {
        Vector3 movementDirection = gameInput.GetNormalizedInput();
        controller.Move(movementDirection * playerSpeed * Time.deltaTime);
    }

    private void ProcessMouseMovement()
    {
        (mouseX, xRotation) = gameInput.GetMouseMovement();

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void ApplyGravity()
    {
        bool isGrounded = gameInput.CheckIfGrounded(groundCheck, groundLayer);

        Vector3 gravityVector = new Vector3();

        if (isGrounded) { gravityVector.y = -2f; }
        else { gravityVector.y += gravity * Time.deltaTime; }

        gravityVector.y = gravity;

        controller.Move(gravityVector * Time.deltaTime);
    }
}
