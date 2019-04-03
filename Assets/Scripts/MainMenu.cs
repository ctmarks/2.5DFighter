using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MainMenu.cs
/// Christopher Marks
/// 4/2/2019
/// </summary>

[RequireComponent(typeof(AudioSource))]                                 // Add audio source

public class MainMenu : MonoBehaviour
{

    public int _selectedButton = 0;                                     // Defines select GUI button
    public float _timeBetweenButtonPress = 0.1f;                        // Defines delay time between button presses
    public float _timeDelay;                                            // Defines delay variable value

    public float _mainMenuVerticalInputTimer;                           // Defines vertical input timer
    public float _mainMenuVerticalInputDelay = 1f;                      // Defines vertical input delay

    public Texture2D _mainMenuBackground;                               // Creates slot in inspector to assign main menu background

    private AudioSource _mainMenuAudio;                                 // Defines naming convention for the main menu audio component
    public AudioClip _mainMenuMusic;                                    // Creates slot in inspector to assign main menu music
    public AudioClip _mainMenuStartButtonAudio;                         // Creates slot in inspector to assign main menu start button
    public AudioClip _mainMenuQuitButtonAudio;                          // Creates slot in inspector to assign main menu quit button

    public float _mainMenuFadeValue;                                    // Defines fade value
    public float _mainMenuFadeSpeed = 0.15f;                            // Defines fade speed

    public float _mainMenuButtonWidth = 100f;                           // Defines main menu button width size
    public float _mainMenuButtonHeight = 25f;                           // Defines main menu button height size
    public float _mainMenuGUIOffset = 10;                               // Defines main menu GUI offset

    private bool _startingOnePlayerGame;                                // Defines if we are starting a one player game
    private bool _startingTwoPlayerGame;                                // Defines if we are starting a two player game
    private bool _quittingGame;                                         // Defines if we are quitting the game


    private bool _ps4Controller;                                        // Creates bool for when ps4 controller is connected
    private bool _xBOXController;                                       // Creates bool for when xBOX controller is connected 

    private string[] _mainMenuButtons = new string[]                    // Creates an array of GUI buttons for the main menu scene
    {
        "_onePlayer",
        "_twoPlayer",
        "_quit"
    };

    private MainMenuController _mainMenuController;                     // Defines naming convention for main menu controller

    private enum MainMenuController                                     // Defines states main menu can exist in
    {
        MainMenuFadeIn = 0,
        MainMenuAtIdle = 1,
        MainMenuFadeOut = 2
    }

    // Start is called before the first frame update
    void Start()
    {
        _startingOnePlayerGame = false;                                 // Starting one player game is false on startup
        _startingTwoPlayerGame = false;                                 // Starting two player game is false on startup
        _quittingGame = false;                                          // Qutting game set to false on startup
        _ps4Controller = false;                                         // Sets ps4 controller to false at start
        _xBOXController = false;                                        // Sets xBOX controller to false at start

        _mainMenuFadeValue = 0;                                         // Main menu fade value set to zero on startup

        _mainMenuAudio = GetComponent<AudioSource>();                   // _mainMenuAudioSource equals audiosource component

        _mainMenuAudio.volume = 0;                                      // Audio volume equals zero on startup
        _mainMenuAudio.clip = _mainMenuMusic;                           // Audio clip equals main menu music
        _mainMenuAudio.loop = true;                                     // Audio source set to loop on startup
        _mainMenuAudio.Play();                                          // Play audio
            

        _mainMenuController = MainMenuController.MainMenuFadeIn;        // State equals Fade in on startup

        StartCoroutine("MainMenuManager");                              // Start main menu manager on startup
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator MainMenuManager()
    {
        while (true)
        {
            switch (_mainMenuController)
            {
                case MainMenuController.MainMenuFadeIn:
                    MainMenuFadeIn();
                    break;
                case MainMenuController.MainMenuAtIdle:
                    MainMenuAtIdle();
                    break;
                case MainMenuController.MainMenuFadeOut:
                    MainMenuFadeOut();
                    break;
            }
            yield return null;
        }
    }

    private void MainMenuFadeIn()
    {
        Debug.Log("MainMenuFadeIn");

        _mainMenuAudio.volume += _mainMenuFadeSpeed * Time.deltaTime;         // Increase volume by the fade speed

        _mainMenuFadeValue += _mainMenuFadeSpeed * Time.deltaTime;            // Increase fade value by the fade speed

        if (_mainMenuFadeValue > 1)                                             // If fade value is greater than 1
            _mainMenuFadeValue = 1;                                             // Then make fade value equal to 1

        if (_mainMenuFadeValue == 1)                                           // If fade value equals 1
            _mainMenuController =                                              // then make state equal to
                MainMenu.MainMenuController.MainMenuAtIdle;                    // main menu at idle
    }

    private void MainMenuAtIdle()
    {
        Debug.Log("MainMenuAtIdle");
        if (_startingOnePlayerGame || _quittingGame == true) ;                  // If starting one player game or quitting game equals true
        _mainMenuController = MainMenu.MainMenuController.MainMenuFadeOut;      // Set main menu controller to fade out
    }

    private void MainMenuFadeOut()
    {
        Debug.Log("MainMenuFadeOut");

        _mainMenuAudio.volume -= _mainMenuFadeSpeed * Time.deltaTime;         // Decrease volume by the fade speed

        _mainMenuFadeValue -= _mainMenuFadeSpeed * Time.deltaTime;            // Decrease fade value by the fade speed

        if (_mainMenuFadeValue < 0)                                             // If fade value is less than 0
            _mainMenuFadeValue = 0;                                             // Then make fade value equal to 0

        if (_mainMenuFadeValue == 0 && _startingOnePlayerGame == true)        // If fade value equals zero AND starting one player game is equal to true
            SceneManager.LoadScene("ChooseCharacter");                                              
    }

    private void MainMenuButtonPress()
    {
        Debug.Log("MainMenuButtonPress");

        GUI.FocusControl(_mainMenuButtons[_selectedButton]);

        switch (_selectedButton)
        {
            case 0:
                _mainMenuAudio.PlayOneShot(_mainMenuStartButtonAudio);  // Play start button audio clip
                _startingOnePlayerGame = true;                          // Set starting one player game to true
                break;
            case 1:
                _mainMenuAudio.PlayOneShot(_mainMenuStartButtonAudio);  // Play start button audio clip
                _startingTwoPlayerGame = true;                          // Set starting two player game to true
                break;
            case 2:
                _mainMenuAudio.PlayOneShot(_mainMenuQuitButtonAudio);   // Play start button audio clip
                _quittingGame = true;                                   // Set quitting game equal to true
                break;
        }
    }
}
