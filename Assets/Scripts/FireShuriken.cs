using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShuriken : MonoBehaviour
{
    //Variablen:
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject shurikenPrefab;
    private System.Random random = new System.Random();
    private int cases = 0;
    private float lastShot = 0f;
    private float currentTime;
    private float nextShot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        if (currentTime - lastShot >= nextShot)    //wenn der gewünschte Abstand zum letzten Feuern erreicht ist, soll erneut gefeuert werden
        {
            lastShot = currentTime;
            cases = random.Next(1, 4);  //damit random von einem der drei Punkte gefeuert werden kann
            switch (cases)
            {
                case 1:
                    Instantiate(shurikenPrefab, firePoint1.position, firePoint1.rotation);  //feuert unten
                    break;
                case 2:
                    Instantiate(shurikenPrefab, firePoint2.position, firePoint2.rotation);  //feuert mitte
                    break;
                case 3:
                    Instantiate(shurikenPrefab, firePoint3.position, firePoint3.rotation);  //feuert oben
                    break;
                default:
                    break;
            }
            //legt den Abstand zum nächsten Feuern random fest
            nextShot = (random.Next(30, 60)) * 0.1f;
        }

    }

}
