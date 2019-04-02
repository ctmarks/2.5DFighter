using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {
        Cursor.visible = false;                         // Set the cursor visible to false on Awake
        Cursor.lockState = CursorLockMode.Locked;       // and lock the cursor on awake also

    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);                        // Don't destroy this gameobject when loading a new scene

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
