using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 50;
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.RightShift))
         {
              Attack();
         }

    }
    
    void Attack()
     {
        //Animation der Schwertattacke
        animator.SetTrigger("Attack");

        //Aufspüren der Feinde
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Schaden am Feind anrichten
       foreach(Collider2D enemy in hitEnemies)
        {
           enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
     }

     void OnDrawGizmosSelected()
     {
        if(attackPoint == null) 
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
     }
        
}
