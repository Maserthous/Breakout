using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GCScript : MonoBehaviour {

    public Text scoreText;

    public static GCScript game;

    private int score;
	
	void Start () {
        game = this;

        score = 0;
        scoreText.text = "Score: " + score;
	}

    public void AddScore(int gainScore)
    {
        score += gainScore;
        scoreText.text = "Score: " + score;
    }
}
