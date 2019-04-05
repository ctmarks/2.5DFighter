using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ChooseCharacter.cs
/// ChrisMarks
/// 4/5/2019
/// </summary>

[RequireComponent(typeof(AudioSource))]                                     // Add audio source when attaching the script

public class ChooseCharacter : ChooseCharacterManager
{

    public float _chooseCharacterInputTimer;                                // Defines choose character input timer
    public float _chooseCharacterInputDelay = 1f;                           // Defines choose character input delay

    private GameObject _characterDemo;                                      // Defines naming convention for selected character game object

    public int _characterSelectState;                                       // Defines naming convention for selected character state

    private enum CharacterSelectModels                                      // Defines which character to load
    {
        BlackRobot = 0,
        WhiteRobot = 1
    }

    // Start is called before the first frame update
    void Start()
    {
        CharacterSelectManager();                                           // Call character select manager on startup
    }

    // Update is called once per frame
    void Update()
    {
        if(_chooseCharacterInputTimer > 0)                                  // If choose character input timer is greater than zero
        {
            _chooseCharacterInputTimer -= 1f * Time.deltaTime;              // Then reduce choose character input timer value
        }

        if(_chooseCharacterInputTimer > 0)                                  // If choose character input timer is greater than zero
        {
            return;                                                         // then do nothing and return
        }

        if(Input.GetAxis("Horizontal") < -0.5f)                             // if input equals horizontal less than minus negative 0.5
        {
            if(_characterSelectState == 0)                                  // if character select state equals zero
            {
                return;                                                     // then return and do nothing
            }

            _characterSelectState--;                                        // Decrease from character select state value
            CharacterSelectManager();                                       // and call Character select manager function

            _chooseCharacterInputTimer = _chooseCharacterInputDelay;        // Make choose character input timer equal to input delay
        }

        if (Input.GetAxis("Horizontal") > 0.5f)                             // if input equals horizontal greater than 0.5
        {
            if (_characterSelectState == 1)                                  // if character select state equals zero
            {
                return;                                                     // then return and do nothing
            }

            _characterSelectState++;                                        // Decrease from character select state value
            CharacterSelectManager();                                       // and call Character select manager function

            _chooseCharacterInputTimer = _chooseCharacterInputDelay;        // Make choose character input timer equal to input delay
        }
    }

    private void CharacterSelectManager()
    {
        switch (_characterSelectState)
        {
            default:
            case 0:
                BlackRobot();
                break;
            case 1:
                WhiteRobot();
                break;
        }
    }

    private void BlackRobot()
    {
        DestroyObject(_characterDemo);                                  // Destroy current character demo object
        _characterDemo =                                                // Character demo game object is equal to
            Instantiate(Resources.Load("BlackRobot")) as GameObject;    // the Black Robot wihin our resources folder as a game object

        _characterDemo.transform.position = new Vector3(-0.5f, 0, -7);  // Set character demo position to a new vector3(*,*,*)

        _robotBlack = true;                                             // Set robot black to true
        _robotWhite = false;
    }

    private void WhiteRobot()
    {

    }

    private void OnGUI()
    {
        
    }
}
