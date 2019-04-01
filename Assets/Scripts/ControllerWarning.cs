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
        if(_controllerDetected == true)                             // If controller detected equals true
        {
            StartCoroutine("WaitToLoadMainMenu");                   // Start WaitToLoadMainMenu function
        }

        if(_controllerConditionsMet == false)                       // If controller conditions met equals false
            return;                                                 // then do nothing and return

        if(_controllerConditionsMet == true)                        // If controller condionts met equals true
        {
            _controllerWarningFadeValue -=                          // Decrease fade value 
                _controllerWarningFadeSpeed * Time.deltaTime;       // by fade speed x time.deltatime
        }

        if(_controllerWarningFadeValue < 0)                         // If fade value is less than zero
            _controllerWarningFadeValue = 0;                        // then set fade value equal to zero

        if(_controllerWarningFadeValue == 0)                        // IF fade value is equal to zero
        {
            _startUpFinished = true;                                // Set startup finished to true
            SceneManager.LoadScene("MainMenu");                     // and Load the MainMenu scene
        }
    }

    private IEnumerator WaitToLoadMainMenu()
    {
        yield return new WaitForSeconds(2);                         // Wait for this (x) many seconds

        _controllerConditionsMet = true;                            // Set controller conditions met to true
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect                                    // Draw texture starting at 0,0
            (0, 0, Screen.width, Screen.height),                    // by the screen width and height
            _controllerWarningBackground);                          // draw the warningbackground

        GUI.color = new Color(1, 1, 1,                              // GUI color is equal to 1,1,1(RGB default)
            _controllerWarningFadeValue);                           // plus the fade value

        GUI.DrawTexture(new Rect                                    // Draw texture starting at 0,0
            (0, 0, Screen.width, Screen.height),                    // by the screen width and height
            _controllerWarningText);                                // draw the warning text

        if(_controllerDetected == true)                             // If controller detected equals true
        {
            GUI.DrawTexture(new Rect                                    // Draw texture starting at 0,0
                (0, 0, Screen.width, Screen.height),                    // by the screen width and height
                _controllerDetectedText);                               // draw the controller detected text
        }

    }
}
