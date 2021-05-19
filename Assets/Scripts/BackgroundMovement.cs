using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private PlayerControll myPlayerControll;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myPlayerControll = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
    }

    // Update is called once per frame
    void Update()
    {
            rb.velocity = new Vector2(0, -myPlayerControll.speedBackground);
        
        if (rb.transform.position.y < -18)
        {
            rb.transform.position = new Vector2(0, 36);
        }
    }
}
