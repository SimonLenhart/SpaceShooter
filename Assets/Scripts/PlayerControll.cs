using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{ 
    public float speedObjects;
    public float speedBackground;
    public Rigidbody2D rb;
    public static int score;
    public int leben;
    public Vector2[] positions;
    public Sprite ufoSprite;
    public Sprite spaceShipSprite;

    private TextMeshProUGUI scoreTextMesh;
    private TextMeshProUGUI lifeTextMesh;
    private int countSpeedColl;
    private bool dauerschuss;
    private Sprite mySprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreTextMesh = GameObject.FindGameObjectWithTag("TextProScore").GetComponent<TextMeshProUGUI>();
        lifeTextMesh = GameObject.FindGameObjectWithTag("TextProLife").GetComponent<TextMeshProUGUI>();

        
        score = 0;
        speedObjects = 4;
        speedBackground = 1;
        leben = 3;
        countSpeedColl = 0;

        scoreTextMesh.text = "Score: 0";
        lifeTextMesh.text = "Leben: 3";

        switch (PlayerPrefs.GetString("player"))
        {
            case "ufo":
                mySprite = ufoSprite;
                break;

            case "spaceShip":
                mySprite = spaceShipSprite;
                break;

            case "":
                mySprite = ufoSprite;
                break;
        }
        this.GetComponent<SpriteRenderer>().sprite = mySprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            SoundMangerScript.Playsound("coinSound");

            randomPlaceObj(other, 50);
            score++;
            scoreTextMesh.text = "Score: " + score.ToString();
        }

        if (other.gameObject.CompareTag("Asteroid"))
        {
            SoundMangerScript.Playsound("crashSound");

            randomPlaceObj(other, 50);
            leben--;
            lifeTextMesh.text = "Leben: " + leben.ToString();

            if (leben == 0)
            {
                if (score > PlayerPrefs.GetInt("Highscore1") )
                {
                    PlayerPrefs.SetInt("Highscore2", PlayerPrefs.GetInt("Highscore1"));
                    PlayerPrefs.SetInt("Highscore1", score);
                    PlayerPrefs.SetString("NameHigh2", PlayerPrefs.GetString("NameHigh1"));

                }
                else
                {
                    if (score > PlayerPrefs.GetInt("Highscore2"))
                    {
                        PlayerPrefs.SetInt("Highscore3", PlayerPrefs.GetInt("Highscore2"));
                        PlayerPrefs.SetInt("Highscore2", score);
                        PlayerPrefs.SetString("NameHigh3", PlayerPrefs.GetString("NameHigh2"));
                    }
                    else
                    {
                        if (score > PlayerPrefs.GetInt("Highscore3"))
                        {
                            PlayerPrefs.SetInt("Highscore3", score);
                        }
                    }
                }
                PlayerPrefs.SetInt("endScore", score);
           
                SceneManager.LoadScene(2);
            }
        }

        if (other.gameObject.CompareTag("Herz"))
        {
            other.transform.position = new Vector2(Random.Range(-4, 4), 200);
            leben++;
            lifeTextMesh.text = "Leben: " + leben.ToString();
        }

        if (other.gameObject.CompareTag("SpeedChange"))
        {
            switch (countSpeedColl)
            {
                case 0:
                    speedObjects += 1;
                    countSpeedColl++;
                    other.transform.position = new Vector2(0, 50);
                    break;

                case 1:
                    speedObjects += 1;
                    countSpeedColl++;
                    other.transform.position = new Vector2(0, 100);
                    break;

                case 2:
                    speedObjects += 1;
                    countSpeedColl++;
                    other.transform.position = new Vector2(0, 100);
                    break;

                case 3:
                    speedObjects += 1;
                    countSpeedColl++;
                    other.transform.position = new Vector2(0, 120);
                    other.gameObject.SetActive(false);
                    break;

                case 4:
                    speedObjects += 1;
                    countSpeedColl++;
                    other.gameObject.SetActive(false);
                    break;
            }
        }

        if (other.gameObject.CompareTag("Dauerschuss"))
        {
            dauerschuss = true;
            randomPlaceObj(other, 200);
        }
    }

    public void randomPlaceObj(Collider2D other, int yDifferenz)
    {
        other.transform.position = new Vector2(Random.Range(-4, 4), Random.Range(12, 12 + yDifferenz));
    }

}
