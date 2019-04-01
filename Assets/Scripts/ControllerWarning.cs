using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ControllerWarning.cs
/// Christopher Marks
/// 4/1/2019
/// </summary>

public class ControllerWarning : ControllerManager
{

    public Texture2D _controllerWarningBackground;                  // Creates slot in inspector to assign the controllerWarningBackground
    public Texture2D _controllerWarningText;                        // Creates slot in inspector to assign the controllerWarningTextMessage
    public Texture2D _controllerDetectedText;                       // Creates slot in inspector to assign the controllerDetectedTextMessage

    public float _controllerWarningFadeValue;                       // Defines the fade value of the warning text
    private float _controllerWarningFadeSpeed = 0.25f;              // Defines the fade speed 
    private bool _controllerConditionsMet;                          // Defines if the controller conditions are met for the game to continue

    // Start is called before the first frame update
    void Start()
    {
        _controllerWarningFadeValue = 1;                            // Fade value equals 1 on startup
        _controllerConditionsMet = false;                           // Controller conditions met is false on startup
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
