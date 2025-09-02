using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public PlayerInputActions playerInputActions;

    [SerializeField] public float mouseSensitivity = 100f;

    private float xRotation;
    private float viewRange = 90f;

    private Transform playerBody;

    private float flashlightButtonPressed;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = FindObjectOfType<PlayerController>().transform;
        
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Flashlight.started += CheckToggleFlashlight;
    }

    public (float, float) GetMouseMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -viewRange, viewRange);

        return (mouseX, xRotation);
    }

    public Vector3 GetNormalizedInput()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        Vector3 x = playerBody.right * inputVector.x * Time.deltaTime;
        Vector3 z = playerBody.forward * inputVector.y * Time.deltaTime;

        Vector3 movementDirection = x + z;

        movementDirection = movementDirection.normalized;

        return movementDirection;
    }

    public bool CheckIfGrounded(Transform groundCheck, LayerMask groundLayer)
    {
        float checkRadius = 0.3f;
        bool isGrounded = !Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);
        return isGrounded;
    }

    public void CheckToggleFlashlight(InputAction.CallbackContext context)
    {

    }
}
