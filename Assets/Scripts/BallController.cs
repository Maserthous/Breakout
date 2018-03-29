using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float speed;
    public float launchX;
    public float launchY;
    public float maxVelX;
    public float minVelY;
    public float maxVelY;

    private Rigidbody2D rBody;
    private Vector2 movement;
    private float x;
    private float y;

    void Start () {
        rBody = this.gameObject.GetComponent<Rigidbody2D>();

        movement = new Vector2(launchX, launchY);
        rBody.velocity = movement * speed;
    }

    private void FixedUpdate()
    {
        //Prevents the ball from going too slowly vertically
        /*if (rBody.velocity.y < minVelY && rBody.velocity.y > -minVelY)
        {
            if (rBody.velocity.y > 0)
                y = minVelY;
            else
                y = -minVelY;
        }
        else
            y = rBody.velocity.y;*/
        if (rBody.velocity.y > 0)
        {
            y = Mathf.Clamp(rBody.velocity.y, minVelY, maxVelY);
        }
        else
        {
            y = Mathf.Clamp(rBody.velocity.y, -minVelY, -maxVelY);
        }

        //Prevent the ball from going too fast
        //y = Mathf.Clamp(y, -maxVelY, maxVelY);
        x = Mathf.Clamp(rBody.velocity.x, -maxVelX, maxVelX);

        rBody.velocity = new Vector2(x, y);
        //Debug.Log("Ball yVel: " + rBody.velocity.y);
    }


}
