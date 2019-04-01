using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ControllerManager.cs
/// Christopher Marks
/// 3/28/2019
/// </summary>
/// 

public class ControllerManager : MonoBehaviour
{
    public Texture2D _ControllerNotDetected;                        // Creates slot in inspector assign controller not detected text

    public bool _pS4Controller;                                     // Creates a bool for when a pS4 controller is connected
    public bool _xBOXController;                                    // Creates a bool for when a XBOX controller is connected
    public bool _controllerDetected;                                // Creates a bool for when a controller is detected

    public static bool _startUpFinished;                            // Creates bool for when startup is finished

    void Awake()
    {
        _pS4Controller = false;                                     // PS4 controller is false on awake
        _xBOXController = false;                                    // XBOX controller is false on awake
        _controllerDetected = false;                                // controller detected is false on awake

        _startUpFinished = false;                                   // Start up finished is false on awake
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);                                    // Don't destroy this gameobject when loading a new scene
    }

    void LateUpdate()
    {
        string[] _joystickNames = Input.GetJoystickNames();         // _joystickNames equals get joystick names from inbuild input

        for (int _js = 0; _js < _joystickNames.Length; _js++)       // Increase counter _js based on joystick names length
        {
            if (_joystickNames[_js].Length == 19)                   // If joystick name equals code 19
            {
                _pS4Controller = true;                              // Set _pS4Controller to true
                _controllerDetected = true;                         // Set _controllerDetected to true
            }
            if (_joystickNames[_js].Length == 33)                   // If joystick name equals code 19
            {
                _xBOXController = true;                             // Set _xBOXController to true
                _controllerDetected = true;                         // Set _controllerDetected to true
            }

            if (_joystickNames[_js].Length != 0)                    // If joystick names does not equal zero
            {
                return;                                             // then do nothing and return
            }

            if(string.IsNullOrEmpty(_joystickNames[_js]))           // If string is null/empty ie no controller detected
            {
                _controllerDetected = false;                        // then set _controllerDetected to false
            }
        }
    }

    private void OnGUI()
    {
        if (_startUpFinished == false)                               // if startup finished equals false
            return;                                                  // then do nothing and return

        if (_controllerDetected == true)                             // if controller detected equals true
            return;                                                  // then do nothing and return

        if (_controllerDetected == false)                            // If controller detected equals false
            GUI.DrawTexture(new Rect(                                // Draw texture
                0, 0,                                                // at this position
                Screen.width, Screen.height),                        // by these dimensions
                _ControllerNotDetected);                             // draw the controller not detected texture
    }
}
