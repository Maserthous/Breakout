using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int score;
    public int upgradeID;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            GCScript.game.AddScore(score);
            GCScript.game.BrickBroken();
            GCScript.game.SpawnUpgrade(upgradeID, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
