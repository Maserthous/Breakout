using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaizoBrick : MonoBehaviour {

    public Color invisible;
    public Color reveal;
    public int score;
    public int upgradeID;

    private bool hit;
    
	void Start () {
        hit = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = invisible;
	}

    private void Update()
    {
        if (GCScript.game.GetWeaken())
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = reveal;
            hit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = reveal;

            if (hit)
            {
                GCScript.game.BrickBroken();
                GCScript.game.SpawnUpgrade(upgradeID, this.transform);
                Destroy(this.gameObject);
            }

            hit = true;
        }
    }
}
