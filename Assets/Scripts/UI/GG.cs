using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// class for GG (Win) scene
public class GG : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // loads MainMenu after key input (SPACE)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
