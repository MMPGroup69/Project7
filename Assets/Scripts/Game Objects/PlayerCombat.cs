using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint; //Punkt an der Attacke stattfindet
    public float attackRange = 1.5f;
    public LayerMask enemyLayers; 
    public LayerMask shurikenLayers; //Erg�nzung f�r Shuriken - Melli
    AudioSource attack;

    public int attackDamage = 60;

    //�berpr�fe jedes Frame, ob Shift-Taste gedr�ckt wird und f�hre dann Attacke aus
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.RightShift))
         {
              Attack();
         }

    }
    
    void Attack()
     {
       //Spiele Attack-Sound nicht, wenn Ninja am Springen ist
       if(!animator.GetBool("IsJumping"))
       {  
        SoundManager.PlaySound("attack");
       }

        animator.SetTrigger("Attack"); //Animation der Schwertattacke


        //Aufsp�ren der Feinde
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Schaden am Feind anrichten
       foreach(Collider2D enemy in hitEnemies)
        {
           //Greife auf die Methode des Feinds zu, die Schaden an ihm anrichtet, wenn hitEnemies mit dem Feind kollidiert
           enemy.GetComponent<Enemy>().TakeDamage(attackDamage); 
        }


        //Erg�nzung Shuriken - Melli
        Collider2D[] hitShuriken = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, shurikenLayers);

        foreach (Collider2D shuriken in hitShuriken)
        {
            shuriken.GetComponent<ShurikenMovement>().destroyed = true; //destroyed wird bei getroffenen Shuriken auf true gesetzt, Rest passiert in ShurikenMovement
        }
     }

     void OnDrawGizmosSelected()
        {
            if(attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }

}
