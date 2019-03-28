using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// SplashScreen.cs
/// Christopher Marks
/// 03/28/2019
/// </summary>


[RequireComponent(typeof(AudioSource))]                                 // Add audio source when attaching script
public class SplashScreen : MonoBehaviour
{
    public Texture2D _splashScreenBackground;                           // Creates slot in inspector for background splashscreen image
    public Texture2D _splashScreenText;                                 // Creates slot in inspector to assign splashscreen text

    private AudioSource _splashScreenAudio;                             // Defines naming convention for audio source component 
    public AudioClip _splashScreenMusic;                                // Creates slot in inspector to assign splash screen music

    private float _splashScreenFadeValue;                               // Defines fade value 
    private float _splashScreenFadeSpeed = .15f;                        // Defines fade speed

    private SplashScreenController _splashScreenController;             // Defines naming convention for splash screen controller

    private enum SplashScreenController                                 // Defines states for splash screen
    {
        SplashScreenFadeIn = 0,
        SplashScreenFadeOut = 1
    }

    void Awake()
    {
        _splashScreenFadeValue = 0;                                     // Fade value equals zero on startup
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;                                         // Set cursor visible state to false
        Cursor.lockState = CursorLockMode.Locked;                       // and lock the cursor

        _splashScreenAudio = GetComponent<AudioSource>();               // Splash screen audio equals the audio source component
        _splashScreenAudio.volume = 0;                                  // Audio volume = 0 on startup
        _splashScreenAudio.clip = _splashScreenMusic;                   // Audio clip equals splash screen music
        _splashScreenAudio.loop = true;                                 // Set audio to loop
        _splashScreenAudio.Play();                                      // Play audio

        _splashScreenController =                                       // State equals
            SplashScreen.SplashScreenController.SplashScreenFadeIn;     // fade in on startup

        StartCoroutine("SplashScreenManager");                          // Start splash screen manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SplashScreenManager()
    {
        while (true)
        {
            switch (_splashScreenController)
            {
                case SplashScreenController.SplashScreenFadeIn:
                    SplashScreenFadeIn();
                    break;
                case SplashScreenController.SplashScreenFadeOut:
                    SplashScreenFadeOut();
                    break;
            }
            yield return null;
        }
    }

    private void SplashScreenFadeIn()
    {
        Debug.Log("SplashScreenFadeIn");

        _splashScreenAudio.volume += 
            _splashScreenFadeSpeed * Time.deltaTime;                    // Increase volume by fade speed
        _splashScreenFadeValue +=
            _splashScreenFadeSpeed * Time.deltaTime;                    // Increase fade value by fade speed

        if (_splashScreenFadeValue > 1)                                 // If fade value is greater than one
            _splashScreenFadeValue = 1;                                 // Then set fade value to 1

        if(_splashScreenFadeValue == 1)                                 // If fade value equals 1 
            _splashScreenController =                                   // Set splash screen controller to equal
                SplashScreenController.SplashScreenFadeOut;             // splash screen fade out
    }

    private void SplashScreenFadeOut()
    {
        Debug.Log("SplashScreenFadeOut");

        _splashScreenAudio.volume -=
            _splashScreenFadeSpeed * Time.deltaTime;                    // Decrease volume by fade speed
        _splashScreenFadeValue -=
            _splashScreenFadeSpeed * Time.deltaTime;                    // Decrease fade value by fade speed

        if (_splashScreenFadeValue < 0)                                 // If fade value is less than zero
            _splashScreenFadeValue = 0;                                 // Then set fade value to zero

        if (_splashScreenFadeValue == 0)                                // If fade value equals 0 
            SceneManager.LoadScene("ControllerWarning");                // Load scene ControllerWarning
    }

    void OnGUI()
    {
        GUI.DrawTexture(                                                // Draw texture starting at 0,0
            new Rect(0, 0, Screen.width, Screen.height),                // by the screen width and height
            _splashScreenBackground);                                   // and draw the background texture

        GUI.color = new Color(1, 1, 1, _splashScreenFadeValue);         // GUI color is equal to (1,1,1) plus fade value

        GUI.DrawTexture(                                                // Draw texture starting at 0,0
            new Rect(0, 0, Screen.width, Screen.height),                // by the screen width and height
            _splashScreenText);                                         // and draw the splash screen text
    }
}                                                                       
