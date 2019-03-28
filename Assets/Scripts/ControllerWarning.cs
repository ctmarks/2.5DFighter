using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ControllerWarning.cs
/// Christopher Marks
/// 3/28/2019
/// </summary>
/// 

public class ControllerWarning : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (_controllerDetected == true)                             // If controller detected equals true
            return;                                                  // then do nothing and return
    }

    private void OnGUI()
    {
        
    }
}
