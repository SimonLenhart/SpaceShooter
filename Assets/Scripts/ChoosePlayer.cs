using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayer : MonoBehaviour
{
    public void selectPlayer(string name)
    {
        PlayerPrefs.SetString("player", name);
    }
}
