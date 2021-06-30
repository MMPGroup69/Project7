using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D rb;

    public int maxHealth = 60;
    int currentHealth;
    // Start is called before the first frame update

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        if (IsFacingRight()){
            //Move right
            rb.velocity = new Vector2(moveSpeed, 0f);

        }else{
            //Move left
            rb.velocity = new Vector2(-moveSpeed, 0f);
            
        }
    }
     private void OnTriggerExit2D(Collider2D collision){
        //Turn
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private bool IsFacingRight(){
        return transform.localScale.x > 0; //0.0001f
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Animation der Verletzung wird abgespielt
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");

        rb.velocity = new Vector2(0f, 0f);

        //Animation vom Sterben
        animator.SetBool("IsDead", true);

        //Disable Enemy
        foreach(BoxCollider2D c in GetComponentsInChildren<BoxCollider2D>()){
            c.enabled = false;
        }

        this.enabled = false;
    }
        
   
}
