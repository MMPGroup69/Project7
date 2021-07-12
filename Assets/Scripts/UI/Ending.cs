using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// class for GAMEOVER scene
public class Ending : MonoBehaviour
{
    void Update()
    {
        // loads MainMenu after key input (SPACE)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
