using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, attackSound, hurtSound, secretSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start(){
        jumpSound = Resources.Load<AudioClip>("jump");
        attackSound = Resources.Load<AudioClip>("attack");
        hurtSound = Resources.Load<AudioClip>("hurt");
        secretSound = Resources.Load<AudioClip>("secret");
        audioSrc = GetComponent<AudioSource>();
    }


    
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "attack":
                audioSrc.PlayOneShot(attackSound);
                break;
            case "hurt":
                audioSrc.PlayOneShot(hurtSound);
                break;
            case "secret":
                audioSrc.PlayOneShot(secretSound);
                break;

        }
    }
}
