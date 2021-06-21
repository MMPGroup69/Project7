using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject keyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //wenn der Spieler den Key "einsammelt" verschwindet er; Es muss �berpr�ft werden dass es sich bei der Kollision um den Spieler handelt!!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HUD.currentKeys += 1;
            Destroy(gameObject);
        }

    }

}
