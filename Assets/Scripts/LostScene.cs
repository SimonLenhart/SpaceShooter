using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LostScene : MonoBehaviour
{
    private TextMeshProUGUI scoreTextMesh;
    private TextMeshProUGUI highscoreTextMesh;

    public TMP_InputField TMPInputField;
    public GameObject saveButton;
    // Start is called before the first frame update
    void Start()
    {
        scoreTextMesh = GameObject.FindGameObjectWithTag("TextProScore").GetComponent<TextMeshProUGUI>();
        highscoreTextMesh = GameObject.FindGameObjectWithTag("TextProHighscore").GetComponent<TextMeshProUGUI>();
       
        scoreTextMesh.text = "Your Score was: " + PlayerPrefs.GetInt("endScore").ToString();
        if (PlayerPrefs.GetInt("endScore") == PlayerPrefs.GetInt("Highscore1"))
        {
            highscoreTextMesh.text = "New " + "Highscore!";
        }
        else
        {
            highscoreTextMesh.text = "";
        }

        if (PlayerPrefs.GetInt("endScore") == PlayerPrefs.GetInt("Highscore1") || PlayerPrefs.GetInt("endScore") == PlayerPrefs.GetInt("Highscore2") || PlayerPrefs.GetInt("endScore") == PlayerPrefs.GetInt("Highscore3"))
        {
            saveButton.SetActive(true);
            TMPInputField.gameObject.SetActive(true);
        }
        
    }


    public void OnSubmit()
    {
        if (PlayerPrefs.GetInt("endScore") == PlayerPrefs.GetInt("Highscore1"))
        {
            PlayerPrefs.SetString("NameHigh1", TMPInputField.text);
        }

        if (PlayerPrefs.GetInt("endScore") == PlayerPrefs.GetInt("Highscore2"))
        {
            PlayerPrefs.SetString("NameHigh2", TMPInputField.text);
        }

        if (PlayerPrefs.GetInt("endScore") == PlayerPrefs.GetInt("Highscore3"))
        {
            PlayerPrefs.SetString("NameHigh3", TMPInputField.text);
        }


    }
}
