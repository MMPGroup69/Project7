using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f; //Geschwindigkeit vom Feind
    Transform leftWayPoint, rightWayPoint; // Endpunkte des Weges
    Vector3 localScale;
    bool movingRight = true; //In welcher Richtung der Feind zeigt
    Rigidbody2D rb;
    public Animator animator;


    public int maxHealth = 60; // Maximale Gesundheit vom Feind
    int currentHealth; //Gegenwärtige Gesundheit

    void Start()
    {
        localScale = transform.localScale; // Initialisiere Skalierung
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // Initialisiere den gesundheitswert am Anfang auf den Maximalwert
        leftWayPoint = GameObject.Find("LeftWayPoint").GetComponent<Transform>();
        rightWayPoint = GameObject.Find("RightWayPoint").GetComponent<Transform>();

    }

    //Überprüfe jedes Frame, ob Feind am Ende seines Vorgeschriebenen Weges ist und in welcher Richtung er sich bewegt. Passe bei Richtungsänderung seine Richtungsanzeige(movingRight) an
    void Update()
    {
        if (transform.position.x > rightWayPoint.position.x)
            movingRight = false;

         if (transform.position.x < leftWayPoint.position.x)
            movingRight = true;

        if(movingRight)
            MoveRight();
        else
            MoveLeft();
    }

    //Steuerung der Bewegung nach rechts
    void MoveRight()
    {
        movingRight = true;
        localScale.x = 2; //Skalierung des Feindes in der Engine
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y); //Geschwindigkeitsvektor, y-position unverändert
    }

    //Steuerung der Bewegung nach links
    void MoveLeft()
    {
        movingRight = false;
        localScale.x = - 2; //gespiegelte Skalierung
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }

     //Feind nimmt schaden
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt"); //Animation der Verletzung wird abgespielt

        if(currentHealth <= 0) // Wenn Gesundheitswert nicht mehr positiv ist, rufe Die() auf
        {
            Die();
        }
    }

    //Feind stirbt
    void Die()
    {
        Debug.Log("Enemy died");

        rb.velocity = new Vector2(0f, 0f); //kann sich nicht mehr bewegen
        animator.SetBool("IsDead", true); //Animation vom Sterben

        foreach(CapsuleCollider2D c in GetComponentsInChildren<CapsuleCollider2D>()) // Deaktivere seine Collider... 
        {
            c.enabled = false;
        }

        this.enabled = false; //... und den Feind
    }

}
