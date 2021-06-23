using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish_collision : MonoBehaviour
{
    public Transform spawnPoint;
    public Scene gamewon;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Spieler hat Siegraum erreicht
        if (collision.tag == "Finish")
        {
            SceneManager.LoadScene("GG");
        }
        if (collision.tag == "DEATH")
        {
            SceneManager.LoadScene("GAMEOVER");
        }

        //wenn der Chara beim runterfallen noch Leben hat soll er respawnen (die Leben werden in PlayerHealth reduziert) und nach rechts schauen
        if (collision.tag == "Falling")
        {
            player.transform.position = spawnPoint.position;
            player.GetComponent<CharacterController2D>().FaceRight();
        }
    }
}
