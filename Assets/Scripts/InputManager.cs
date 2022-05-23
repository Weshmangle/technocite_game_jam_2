using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private TouchControls touchControls;
    public int stateSpeaker = 0;

    public Vector2 positionTouch;
    public bool clicked;

    private void Awake()
    {
        touchControls = new TouchControls();
        Instance = this;
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }
    private void Start()
    {
         touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
         touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    void Update()
    {
        positionTouch = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        var position = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        
        if(position.y > Screen.height/2)
        {
            Debug.Log("Player 1 touch" + position.x + ", " + position.y);
        }
        else
        {
            Debug.Log("Player 2 touch" + position.x + ", " + position.y);
        }

        clicked = true;
    }
    
    private void EndTouch(InputAction.CallbackContext context)
    {
        clicked = false;
        Debug.Log("end");
    }
}
