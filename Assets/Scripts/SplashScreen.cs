﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void SplashScreenFadeIn()
    {
        Debug.Log("SplashScreenFadeIn");
    }

    private void SplashScreenFadeOut()
    {
        Debug.Log("SplashScreenFadeOut");
    }
}
