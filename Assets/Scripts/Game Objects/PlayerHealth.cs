using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator; // für Verletzung
    public static int lives = 5;
    public bool isAlive = true;
    public int shurikenDmg = 1;
    public int fallingDmg = 2;
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
        
        //Falling DMG
        if (collision.tag == "Falling")
        {
            lives = lives - fallingDmg;
        }

    }


    void OnCollisionEnter2D (Collision2D col) // Methode für die Kollisionserkennung mit dem Feind
    {
         if(col.gameObject.tag.Equals("Enemy"))
        {
            lives = lives - enemyDmg;
            SoundManager.PlaySound("hurt"); // Spiele Sound bei Verletzung ab
            animator.SetTrigger("Hurt");  //Spiele Hurt Animation ab
        }
    }

}
