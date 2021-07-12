using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish_collision : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject player;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Spieler hat Siegraum erreicht
        if (collision.tag == "Finish")
        {
            SceneManager.LoadScene("GG");
        }

        //wenn der Chara beim runterfallen noch Leben hat soll er respawnen (die Leben werden in PlayerHealth reduziert) und nach rechts schauen
        if (collision.tag == "Falling")
        {
            player.transform.position = spawnPoint.position;
            player.GetComponent<CharacterController2D>().FaceRight();
        }
    }
}
