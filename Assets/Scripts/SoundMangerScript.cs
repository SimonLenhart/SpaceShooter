using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMangerScript : MonoBehaviour
{
    public static AudioClip fireSound, coinSound, crashSound;

    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip>("Sounds/laserSound");
        coinSound = Resources.Load<AudioClip>("Sounds/CoinSound");
        crashSound = Resources.Load<AudioClip>("Sounds/crashSound");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void Playsound (string clip)
    {
        switch (clip)
        {
            case "laserSound":
                audioSrc.PlayOneShot(fireSound);
                break;

            case "coinSound":
                audioSrc.PlayOneShot(coinSound);
                break;

            case "crashSound":
                audioSrc.PlayOneShot(crashSound);
                break;
        }
    }
}


