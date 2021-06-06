using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenMovement : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody2D rb;
    public bool destroyed = false;  //wenn das Objekt vom Spieler zerstört wird, auf true setzen und Destroy(gameObject)
    private int frames = 6000; //der Abstand nach dem die Objekte standardmäßig zerstört werden

    
    // Start is called before the first frame update
    void Start()
    {
        //die erzeugten Shuriken sollen sich mit gewünschter Geschwindigkeit Richtung Spieler (nach links) bewegen:
        rb.velocity = transform.right * speed;
        transform.eulerAngles = Vector3.right * 1; //damits richtig rum rotiert
    }


    // Update is called once per frame
    void Update()
    {
        //nach einer gewissen Zeit oder einer gewissen Distanz sollen die Objekte standardmäßig zerstört werden
        frames--;
        if (frames <= 0)
        {
            Destroy(gameObject);
            frames = 6000;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //wenn der Spieler getroffen wird, soll dessen Leben reduziert werden

        Destroy(gameObject);    //bei Kollision soll das Objekt zerstört werden
    }

}
