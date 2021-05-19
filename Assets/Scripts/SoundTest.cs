using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundTest : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer masterMixer;
    public Button derButton;

    public void SetSoundVol(float soundLvl)
    {
        masterMixer.SetFloat("soundVol", soundLvl);
    }
    public void SetThemeVol(float themeLvl)
    {
        masterMixer.SetFloat("themeVol", themeLvl);
    }

    public void btnWeg(bool boolVal)
    {
        derButton.gameObject.SetActive(boolVal);
        Debug.Log(boolVal);
    }
}
