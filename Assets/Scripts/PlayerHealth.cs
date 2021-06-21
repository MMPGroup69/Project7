using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int lives = 2;
    public bool isAlive = true;
    public int hitCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //wenn keine Leben mehr übrig sind wird GameOver geladen
        if(lives <= 0)
        {
            isAlive = false;
            SceneManager.LoadScene("GAMEOVER");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // von Shuriken darf man zweimal getroffen werden, der Hit Counter zählt mit und wird zurückgesetzt wenn sich die Leben verringert haben
        if (collision.tag == "Shuriken")
        {
            hitCounter++;
        }

        // wenn man vom Feind getroffen wird, wird sofort das Leben reduziert
        if (collision.tag == "Enemy" || hitCounter == 2)
        {
            lives--;
            hitCounter = 0;
        }
    }

}
