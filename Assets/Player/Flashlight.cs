using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] private Transform toggle;
    [SerializeField] private float toggleXRotation;
    [SerializeField] private AudioSource source;
    [SerializeField] private Material greenMaterial;
    [SerializeField] private Material redMaterial;

    private GameInput gameInput;
    private Battery battery;

    private MeshRenderer toggleColor;

    private bool flashlightOn;

    private void Start()
    {
        battery = GetComponent<Battery>();
        toggleColor = toggle.GetComponent<MeshRenderer>();

        gameInput = FindObjectOfType<GameInput>();
        gameInput.playerInputActions.Player.Flashlight.started += FlashlightLogic;
    }

    private void Update()
    {
        if (flashlightOn)
        {
            battery.DrainBattery();
        }
        
        if (battery.OutOfBattery && flashlightOn)
        {
            ToggleFlashlight();
        }
    }

    private void FlashlightLogic(InputAction.CallbackContext context)
    {
        if (!battery.OutOfBattery)
        {
            ToggleFlashlight();
        }
    }

    private void FlipToggle()
    {
        if (flashlightOn && !battery.OutOfBattery)
        {
            toggle.transform.localEulerAngles = new Vector3(toggleXRotation, 0f, 0f);
            toggleColor.material = greenMaterial;
        }
        else
        {
            toggle.transform.localEulerAngles = new Vector3(-toggleXRotation, 0f, 0f);
            toggleColor.material = redMaterial;
        }
    }

    private void ToggleFlashlight()
    {
        flashlightOn = !flashlightOn;
        source.Play();
        FlipToggle();
        flashlight.SetActive(flashlightOn);
    }
}