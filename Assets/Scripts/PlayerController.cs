using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float angle;

    private Rigidbody2D rBody;
    private Vector2 movement;

    private void Start()
    {
        rBody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rBody = this.gameObject.GetComponent<Rigidbody2D>();
        rBody.velocity = movement * speed;
    }
}
