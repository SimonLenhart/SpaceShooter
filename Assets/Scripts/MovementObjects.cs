using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObjects : MonoBehaviour
{
    private PlayerControll myPlayerControll;
    private Rigidbody2D rb;
    private Collider2D coll2D;

    // Start is called before the first frame update
    void Start()
    {
        myPlayerControll = GameObject.Find("Player").GetComponent<PlayerControll>();
        rb = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -myPlayerControll.speedObjects);

        if (rb.transform.position.y < -15)
        {
            myPlayerControll.randomPlaceObj(coll2D, 60) ;
        }
    }
}
