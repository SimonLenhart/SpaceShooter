using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickControll : MonoBehaviour
{
    private float deltaX;
    private Rigidbody2D rb;
    private PlayerControll myPlayerControll;

    // *******************Joystick part: ********************
    protected Button shootButton;
    protected bool jump;

    public Transform firePoint;
    public LineRenderer lineRenderer;

 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myPlayerControll = GetComponent<PlayerControll>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    break;

                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, -3));
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;

            }
        }

        // Debuggin on Laptop Part

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, 15);
        SoundMangerScript.Playsound("laserSound");

        if (hitInfo)
        {
            if (hitInfo.transform.name.Contains("Coin"))
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
                myPlayerControll.randomPlaceObj(hitInfo.collider, 50);
            }

            if (hitInfo.transform.name.Contains("Asteroid"))
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
                myPlayerControll.randomPlaceObj(hitInfo.collider, 50);
            }

            if (hitInfo.transform.name.Contains("herz"))
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
                myPlayerControll.randomPlaceObj(hitInfo.collider, 200);
            }
        }
        else
        {
            // draw line
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + new Vector3(0,15,0));
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.1f);

        lineRenderer.enabled = false;

    }

    public void HelpShoot()
    {
        StartCoroutine(Shoot());
    }
    
    }

