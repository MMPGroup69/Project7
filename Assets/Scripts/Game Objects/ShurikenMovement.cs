using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenMovement : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;
    public bool destroyed = false;  //wenn das Objekt vom Spieler zerstört wird, auf true setzen und Destroy(gameObject)
    
    //um den Abstand nach dem die Objekte standardmäßig zerstört werden zu berechnen
    private float startTime;
    private float currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        //die erzeugten Shuriken sollen sich mit gewünschter Geschwindigkeit Richtung Spieler (nach links) bewegen:
            rb.velocity = transform.right * speed;
            transform.eulerAngles = Vector3.right * 1; //damits richtig rum rotiert
    }


    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        //wenn der Spieler ein Shuriken trifft, wird es zerstört
        //nach einer gewissen Zeit oder einer gewissen Distanz sollen die Objekte standardmäßig zerstört werden
        if (currentTime - startTime >= 3.3 || destroyed == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);    //bei Kollision soll das Objekt zerstört werden; Es muss noch überprüft werden dass es sich nicht um eine Münze oder Schlüssel handelt!!!
        }
    }

}
