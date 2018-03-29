using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float xMin;
    public float xMax;
    public float ballSpeed;
    public float angle;
    public GameObject ball;
    public Transform ballSpawn;

    public static PlayerController pc;

    private Rigidbody2D rBody;
    private Vector2 movement;
    private bool ballReady;

    private void Start()
    {
        pc = this;
        rBody = this.gameObject.GetComponent<Rigidbody2D>();

        ballReady = true;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && ballReady)
        {
            Instantiate(ball, ballSpawn.position, ballSpawn.rotation);
            ballReady = false;
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Mouse X");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rBody = this.gameObject.GetComponent<Rigidbody2D>();
        rBody.velocity = movement * speed;
        rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, xMin, xMax), rBody.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            //other.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity / ballSpeed;

            float x = (other.transform.position.x - transform.position.x) * angle;
            movement = new Vector2(x, other.GetComponent<Rigidbody2D>().velocity.y / ballSpeed);
            other.GetComponent<Rigidbody2D>().velocity = movement * ballSpeed;
        }
    }

    public void ReadyBall()
    {
        ballReady = true;
    }
}
