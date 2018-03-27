using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float speed;
    public float launchX;
    public float launchY;
    public float minVelY;
    public float maxVelX;
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Prevents the ball from going too slowly vertically
        if (rBody.velocity.y < minVelY && rBody.velocity.y > -minVelY)
        {
            if (rBody.velocity.y > 0)
                y = minVelY;
            else
                y = -minVelY;
        }
        else
            y = rBody.velocity.y;

        //Prevent the ball from going too fast
        if (rBody.velocity.y > maxVelY)
            y = maxVelY;
        else if (rBody.velocity.y < -maxVelY)
            y = -maxVelY;
        else
            y = rBody.velocity.y;

        if (rBody.velocity.x > maxVelX)
            x = maxVelX;
        else if (rBody.velocity.x < -maxVelX)
            x = -maxVelX;
        else 
            x = rBody.velocity.x;

        rBody.velocity = new Vector2(x, y);
    }


}
