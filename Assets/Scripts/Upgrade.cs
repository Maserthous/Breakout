using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

    public float speed;
    public int upgradeID;
    public int score;

    private Rigidbody2D rBody;

	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();

        rBody.velocity = new Vector2(0, -1) * speed;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GCScript.game.AddScore(score);

            if (upgradeID == 1)
            {
                GCScript.game.ExtendPaddle();
                Destroy(this.gameObject);
            }

            if (upgradeID == 2)
            {
                GCScript.game.TwinBall();
            }

            if (upgradeID == 3)
            {
                //Debug.Log("Weaken");
                GCScript.game.Weaken();
                Destroy(this.gameObject);
            }
        }
    }
}
