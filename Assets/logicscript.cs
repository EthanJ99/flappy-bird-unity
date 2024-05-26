using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    private int score = 0;
    private bool playing;

    // public Text scoreText;
    public TextMeshProUGUI tmpro;
    public GameObject gameOverScreen;

    void Start()
    {
        playing = true;
        updateScoreText();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreIncrement)
    {
        if (playing)
        {
            // Only update score if bird still alive
            score += scoreIncrement;
            updateScoreText();
        }

    }

    private void updateScoreText()
    {
        // scoreText.text = score.ToString();
        tmpro.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        playing = false;
    }

    public bool gameIsPlaying()
    {
        return playing;
    }

}
