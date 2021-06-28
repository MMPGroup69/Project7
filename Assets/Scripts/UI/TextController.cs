using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI storytext;
    //public TextMeshProUGUI controltext;
    public string story;
    //public string controls;
    public float textSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WriteText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WriteText()
    {
        foreach(char character in story.ToCharArray())
        {
            storytext.text += character;
            yield return new WaitForSeconds(textSpeed);
        }

        //foreach(char character in controls.ToCharArray())
        //{
        //    controltext.text += character;
        //    yield return new WaitForSeconds(textSpeed);
        //}
    }

}
