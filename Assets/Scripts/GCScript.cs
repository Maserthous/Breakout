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
    public GameObject endBlack;
    public Text gameOverText;
    public Text restartText;
    public Text winText;
    public int lives;
    public GameObject extend;
    public int extendDuration;
    public float extendScale;
    public GameObject twin;
    public GameObject ball2;
    public GameObject weaken;

    public static GCScript game;
    public static bool weak;
    
    private int bricks;
    private int score;
    private int level;
    private bool gameOver;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        level1.gameObject.SetActive(false);
        level2.gameObject.SetActive(false);
        level3.gameObject.SetActive(false);

        game = this;

        weak = false;

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void SpawnUpgrade(int id, Vector3 position)
    {
        if (id == 1)
            Instantiate(extend, position, Quaternion.identity);
        if (id == 2)
            Instantiate(twin, position, Quaternion.identity);
        if (id == 3)
            Instantiate(weaken, position, Quaternion.identity);
    }

    public void ExtendPaddle()
    {
        StartCoroutine(PlayerController.pc.Extended(extendDuration, extendScale));
    }

    public void TwinBall()
    {
        GameObject ball = GameObject.Find("Ball(Clone)");
        Instantiate(ball2, ball.transform.position, ball.transform.rotation);
        GameObject.Find("Boundary").gameObject.GetComponent<BoundaryDestroyer>().AddTwin();
    }

    public void Weaken()
    {
        weak = true;
    }

    public bool GetWeak()
    {
        return weak;
    }

    public void NextLevel()
    {
        Destroy(GameObject.Find("Ball(Clone)"));
        Destroy(GameObject.Find("Ball(Clone)"));
        Destroy(GameObject.Find("Ball(Clone)"));
        Destroy(GameObject.Find("Ball(Clone)"));
        Destroy(GameObject.Find("Ball(Clone)"));
        Destroy(GameObject.Find("Ball(Clone)"));
        Destroy(GameObject.Find("Ball(Clone)"));
        Destroy(GameObject.FindWithTag("Upgrade"));
        Destroy(GameObject.FindWithTag("Upgrade"));
        GameObject.Find("Boundary").gameObject.GetComponent<BoundaryDestroyer>().ResetTwin();
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

        PlayerController.pc.ReadyBall();
    }

    public void Win()
    {
        endBlack.gameObject.SetActive(true);
        winText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        winText.text = "You Win";
        restartText.text = "Press r to restart";
        gameOver = true;
    }

    public void GameOver()
    {
        endBlack.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        gameOverText.text = "Game Over";
        restartText.text = "Press r to restart";
        gameOver = true;
    }
}
