using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public void LoadMMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MMENU");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("RETRY");
    }
}
