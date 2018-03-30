using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour {

    private int twin;

    private void Start()
    {
        twin = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            Destroy(other.gameObject);

            if (twin > 0)
            {
                twin--;
            }
            else
            {
                GCScript.game.AddDeath();
            }
        }

        if (other.tag == "Upgrade")
        {
            Destroy(other.gameObject);
        }
    }

    public void AddTwin()
    {
        twin++;
    }

    public void ResetTwin()
    {
        twin = 0;
    }
}
