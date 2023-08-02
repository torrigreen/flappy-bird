using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    private int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    public AudioSource scoreSound;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!gameOverScreen.activeSelf)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            scoreSound.Play();
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);

        highScore = PlayerPrefs.GetInt("highScore");
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            PlayerPrefs.Save();
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
