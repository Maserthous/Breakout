using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBrick : MonoBehaviour {

    public int score;
    public int health;
    public Color cracked;
    public Color damaged;
    public int upgradeID;

    private void Start()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            health--;

            GCScript.game.AddScore(score);

            if (health == 2)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = cracked;
            }

            if (health == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = damaged;
            }

            if (health <= 0)
            {
                GCScript.game.BrickBroken();
                GCScript.game.SpawnUpgrade(upgradeID, this.transform);
                Destroy(this.gameObject);
            }
        }
    }
}
