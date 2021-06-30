using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 1.5f;
    public LayerMask enemyLayers;
    public LayerMask shurikenLayers; //Ergänzung für Shuriken - Melli
    AudioSource attack;

    public int attackDamage = 60;
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

        //Animation der Schwertattacke
        animator.SetTrigger("Attack");


        //Aufspüren der Feinde
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Schaden am Feind anrichten
       foreach(Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }


        //Ergänzung Shuriken - Melli
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
