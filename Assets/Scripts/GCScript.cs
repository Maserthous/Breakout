using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GCScript : MonoBehaviour
{

    public GameObject level1;
    public int level1Bricks;
    public GameObject level2;
    public int level2Bricks;
    public GameObject level3;
    public int level3Bricks;
    public Text scoreText;
    public Text livesText;
    public Text gameOverText;
    public Text restartText;
    public Text winText;
    public int lives;
    public GameObject upgrade1;
    public GameObject upgrade2;
    public GameObject upgrade3;

    public static GCScript game;
    public static bool weaken;

    private int bricks;
    private int score;
    private int level;
    private bool gameOver;

    void Start()
    {
        game = this;

        weaken = false;

        gameOver = false;
        bricks = 0;
        score = 0;
        level = 0;
        scoreText.text = "Score:" + score;
        livesText.text = "Balls:" + lives;

        NextLevel();
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

    public void BrickBroken()
    {
        bricks--;
        if (bricks <= 0)
            NextLevel();
    }

    public void AddScore(int gainScore)
    {
        score += gainScore;
        scoreText.text = "Score:" + score;
    }

    public void SpawnUpgrade(int id, Transform position)
    {
        if (id == 1)
            Instantiate(upgrade1, position);
        if (id == 2)
            Instantiate(upgrade2, position);
        if (id == 3)
            Instantiate(upgrade3, position);
    }

    public void NextLevel()
    {
        Destroy(GameObject.Find("Ball(Clone)"));
        level++;
        if (level == 1)
        {
            level1.gameObject.SetActive(true);
            bricks = level1Bricks;
        }

        if (level == 2)
        {
            level1.gameObject.SetActive(false);
            level2.gameObject.SetActive(true);
            bricks = level2Bricks;
        }

        if (level == 3)
        {
            level2.gameObject.SetActive(false);
            level3.gameObject.SetActive(true);
            bricks = level3Bricks;
        }

        if (level == 4)
        {
            Win();
        }
    }

    public void Win()
    {
        winText.gameObject.SetActive(true);
        winText.text = "You Win";
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        gameOverText.text = "Game Over";
        restartText.text = "Press r to restart";
        gameOver = true;
    }

    public void Weaken()
    {
        weaken = true;
    }

    public bool GetWeaken()
    {
        return weaken;
    }
}
