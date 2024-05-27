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
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;

    public AudioSource audioSource;
    public AudioClip gameOverSound;
    public AudioClip scoreSound;

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
            audioSource.clip = scoreSound;
            audioSource.Play();
            score += scoreIncrement;
            updateScoreText();
        }

    }

    private void updateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        // Check we haven't already triggered a game over (avoids duplicate game over SFX)
        if ( gameIsPlaying() )
        {
            audioSource.clip = gameOverSound;
            audioSource.Play();
            gameOverScreen.SetActive(true);
            playing = false;
        }
    }

    public bool gameIsPlaying()
    {
        return playing;
    }

}
