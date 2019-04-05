using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ChooseCharacterManager.cs
/// Christopher Marks
/// 4/4/2019
/// </summary>
/// 

public class ChooseCharacterManager : MonoBehaviour
{

    public static bool _robotBlack;                 // Defines if RobotBlack is selected
    public static bool _robotWhite;                 // Defines if RobotWhite is selected

    private void Awake()
    {
        _robotBlack = false;                        // RobotBlack is false on startup
        _robotWhite = false;                        // RobotWhite is false on startup
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);                    // Don't destroy this game object when loading a new scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
