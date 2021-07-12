using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public CharacterController2D controller; //bezieht sich auf das Skript CharacterController2D in Unity
    public Animator animator; 
    public Rigidbody2D rb;
    public float runSpeed = 40f; // Geschwindigkeit beim Laufen
    float horizontalMove = 0f; //Anfangsgeschwindigkeit = 0
    bool jump = false; // Um festzulegen, ob Player springt oder nicht
    AudioSource step;

    void Start ()
    {
        step = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

   //Auf dieses Event kann dann bei der Laufanimation zugegriffen werden. Wenn die Animation abgespielt wird, führe auch Step() aus (d.h. Spiele den entsprechenden Sound ab)
   public void Step () // 
    {
        step.Play();

    }

    // Update in jedem Frame, prüft hauptsächlich auf User-Inputs
    void Update() 
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed; // Richtung * Geschwindigkeit (neg. Wert wenn Bewegung links, pos.Wert, wenn Bewegung rechts)
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")) // Sobald die Tasten, die im InputManager unter Jump gekennzeichnet sind, gedrückt werden, führe Sprungbewegung mitsamt Animation und Sound aus
        {
            if(!animator.GetBool("IsJumping")) // Sorgt dafür, dass Sprungsound nicht mehrmals hintereinander während des Springens ertönt
            {  
                SoundManager.PlaySound("jump");
                jump = true;
                animator.SetBool("IsJumping", true);
            }
        }
       
    }

  // Update der Bewegung wird eine feste Anzahl pro Sekunde aufgerufen
  void FixedUpdate () 
    {  
        // Move() aus CharacterController2D wird ausgeführt mit Input jump aus dieser Klasse und horizontalMove * Time.fixedDeltaTime
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump); //fixedDeltaTime ist die vergangene Zeit seit dem letzten Funktionsaufruf (horizontalMove * Time.fixedDeltaTime geht sicher, dass die Playergeschwindigkeit konsistent bleibt)
        jump = false;

        //Fall-Animation
        if(rb.velocity.y < -6.6f)
        {
            animator.SetBool("IsFalling", true);
        }
        else if (rb.velocity.y >= -6.6f)
        {
           animator.SetBool("IsFalling", false);
        }

    }

     // Beim Landen wieder Idle-Animation, ausgelöst durch false-setzen von IsJumping
    public void  OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

   



   
}