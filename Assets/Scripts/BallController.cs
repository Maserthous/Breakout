using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float speed;
    public float angle;

    private Rigidbody2D rBody;
    private Vector2 movement;

    void Start () {
        rBody = this.gameObject.GetComponent<Rigidbody2D>();

        movement = new Vector2(0, -1);
        rBody.velocity = movement * speed;
    }
	
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            float x = (transform.position.x - other.transform.position.x) * angle;
            movement = new Vector2(x, rBody.velocity.y / speed);
            rBody.velocity = movement * speed;
        }
    }
}
