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
    private int frames = 0;
    private int cases = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frames <= 0)    //wenn der gewünschte Abstand zum letzten Feuern erreicht ist, soll erneut gefeuert werden; soll noch ergänzt werden damit es Abhängig von der Entfernung des Chara ausgelöst wird
        {
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
            frames = random.Next(2500, 7000);   //legt den Abstand zum nächsten Feuern random fest
        }

        if (frames > 0)
        {
            frames--;   //dekrementiert frames solange sie größer 0 sind, bei 0 wird dann wieder gefeuert
        }
    }

}
