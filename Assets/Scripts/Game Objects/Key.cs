using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject keyPrefab;
    bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //wenn der Spieler den Key "einsammelt" verschwindet er; Es muss überprüft werden dass es sich bei der Kollision um den Spieler handelt!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isCollected == false)
        {
            isCollected = true;
            keyPrefab.GetComponent<Renderer>().enabled = false;
            GetComponent<AudioSource>().Play();
            HUD.currentKeys += 1;
            Destroy(gameObject, 0.5f);
        }

    }

}
