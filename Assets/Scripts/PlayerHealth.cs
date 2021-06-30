using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator; // für Verletzung - Aylin
    public static int lives = 5;
    int currentLives;
    public bool isAlive = true;
    public int shurikenDmg = 1;
    public int enemyDmg = 2;
    public int fallingDmg = 2;


    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
        currentLives = 5;
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
        //Debug.Log("health = " + lives);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Shuriken DMG 
        if (collision.tag == "Shuriken")
        {
            lives = lives - shurikenDmg;
            SoundManager.PlaySound("hurt"); // Spiele Sound bei Verletzung ab
            animator.SetTrigger("Hurt");    //Spiele Hurt Animation ab
        }

        // Enemy DMG
        //if (collision.tag == "Enemy")
        //{
        //   lives = lives - enemyDmg;
        //    SoundManager.PlaySound("hurt"); // Spiele Sound bei Verletzung ab  
        //    animator.SetTrigger("Hurt");    //Spiele Hurt Animation ab
        //}

        // Falling DMG
        if (collision.tag == "Falling")
        {
            lives = lives - fallingDmg;
        }
    }

    public void TakeDamage (int damage) {
        currentLives -= damage;
        lives = currentLives;
        SoundManager.PlaySound("hurt"); // Spiele Sound bei Verletzung ab
        animator.SetTrigger("Hurt"); 
        if (currentLives <= 0)
        {
            isAlive = false;
            SceneManager.LoadScene("GAMEOVER");
        }
    }

}
