using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI storytext; //uebergibt story canvas
    public string story; //text der erscheinen soll
    public float textSpeed; //geschwindigkeit
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WriteText());
    }


    IEnumerator WriteText()
    {
        //fuegt jeden Buchstaben nach einer gewissen Zeit an, so dass der Text Stueck fuer Stueck auftaucht
        foreach(char character in story.ToCharArray())
        {
            storytext.text += character;
            yield return new WaitForSeconds(textSpeed);
        }

    }

}
