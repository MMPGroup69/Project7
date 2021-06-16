using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //wenn der Spieler die Münzen einsammelt, verschwinden sie; Es muss überprüft werden, dass es sich auch um den Spieler handelt!!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        //anschließend muss der Münz-Counter erhöht werden
    }

}
