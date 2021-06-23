using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public static int lives;
    public bool isAlive = true;
    public int shurikenDmg = 1;
    public int enemyDmg = 2;


    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //wenn keine Leben mehr übrig sind wird GameOver geladen
        if (lives <= 0)
        {
            isAlive = false;
            SceneManager.LoadScene("GAMEOVER");
        }
        Debug.Log("health = " + lives);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Shuriken DMG 
        if (collision.tag == "Shuriken")
        {
            lives = lives - shurikenDmg;
        }

        // Enemy DMG
        if (collision.tag == "Enemy")
        {
            lives = lives - enemyDmg;
        }
    }

}
