using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    private TextMeshProUGUI highscore1;
    private TextMeshProUGUI highscore2;
    private TextMeshProUGUI highscore3;
    // Start is called before the first frame update
    void Start()
    {
        highscore1 = GameObject.FindGameObjectWithTag("Highscore1").GetComponent<TextMeshProUGUI>();
        highscore2 = GameObject.FindGameObjectWithTag("Highscore2").GetComponent<TextMeshProUGUI>();
        highscore3 = GameObject.FindGameObjectWithTag("Highscore3").GetComponent<TextMeshProUGUI>();

        highscore1.text = "#1: " + PlayerPrefs.GetString("NameHigh1", "") + " " + PlayerPrefs.GetInt("Highscore1", 0).ToString();
        highscore2.text = "#2: " + PlayerPrefs.GetString("NameHigh2", "") + " " + PlayerPrefs.GetInt("Highscore2", 0).ToString();
        highscore3.text = "#3: " + PlayerPrefs.GetString("NameHigh3", "") + " " + PlayerPrefs.GetInt("Highscore3", 0).ToString();

    }
}
