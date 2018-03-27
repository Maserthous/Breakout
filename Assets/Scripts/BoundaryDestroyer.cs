﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour {



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            Destroy(other.gameObject);

            GCScript.game.AddDeath();
        }
    }
}