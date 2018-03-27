using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    public int score;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            GCScript.game.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}
