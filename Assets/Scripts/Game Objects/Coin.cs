using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinPrefab;
    bool isCollected = false;
    

    //wenn der Spieler die M�nzen einsammelt, verschwinden sie und der Counter erh�ht sich
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isCollected == false)
        {
            isCollected = true;
            coinPrefab.GetComponent<Renderer>().enabled = false;
            GetComponent<AudioSource>().Play();
            HUD.currentCoins += 1;
            Destroy(gameObject, 0.5f);
        }
    }

}
