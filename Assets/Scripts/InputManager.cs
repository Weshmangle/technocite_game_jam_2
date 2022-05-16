using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private TouchControls touchControls;
    public int stateSpeaker = 0;

    private void Awake() {
        touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        touchControls.Enable();
        Debug.Log("Height " + Screen.height);
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
        //Debug.Log(touchControls.Touch.TouchPosition.ReadValue<Vector2>());
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
    }
    
    private void EndTouch(InputAction.CallbackContext context)
    {
        //Debug.Log("end touch");
    }
}
