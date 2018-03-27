using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GCScript : MonoBehaviour {

    public Text scoreText;
    public Text livesText;
    public Text gameOverText;
    public Text restartText;
    public int lives;

    public static GCScript game;

    private int score;
    private bool gameOver;
	
	void Start () {
        game = this;

        gameOver = false;
        score = 0;
        scoreText.text = "Score:" + score;
        livesText.text = "Balls:" + lives;
	}

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Breakout");
            }
        }

        if (Input.GetButton("Cancel"))
            Application.Quit();
    }

    public void AddDeath()
    {
        lives--;
        livesText.text = "Balls:" + lives;

        if (lives <= 0)
        {
            GameOver();
        }
        else
            PlayerController.pc.ReadyBall();
    }

    public void AddScore(int gainScore)
    {
        score += gainScore;
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        gameOverText.text = "Game Over";
        restartText.text = "Press r to restart";
        gameOver = true;
    }
}
