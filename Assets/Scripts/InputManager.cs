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

    private void StartTouch(InputAction.CallbackContext context)
    {
        var position = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
        
        Debug.Log("end toch " + position.x + ", " + position.y);
        
        if(position.y > Screen.height)
        {
            //GameManager.Instance;
        }
    }
    
    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("end toch");
    }
}
