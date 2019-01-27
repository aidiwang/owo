using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static AudioClip slimePop, slimeJump, slimeSquish, chomp;
    static AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        slimePop = Resources.Load<AudioClip>("pop3");
        slimeJump = Resources.Load<AudioClip>("jump");
        slimeSquish = Resources.Load<AudioClip>("squish1");
        chomp = Resources.Load<AudioClip>("chomp");
        audioSource = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "pop":
                audioSource.PlayOneShot(slimePop);
                break;
            case "jump":
                audioSource.PlayOneShot(slimeJump);
                break;
            case "squish":
                audioSource.PlayOneShot(slimeSquish);
                break;
            case "chomp":
                audioSource.PlayOneShot(slimeSquish);
                break;


        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
}
