using System.Collections;
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

    private SplashScreenController splashScreenController;              // Defines naming convention for splash screen controller

    private enum SplashScreenController                                 // Defines states for splash screen
    {
        SplashScreenFadeIn = 0,
        SplashScreenFadeOut = 1
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
