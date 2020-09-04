using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public PlayerController player;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public SnakeCount score;

    private bool gameIsOver;

    void Start()
    {
        gameIsOver = false;
    }

    void Update ()
    {
        if (player.currentHealth <= 0)
        {
            GameOverSequence();
        }
    }

    private void GameOverSequence()
    {
        if (!gameIsOver)
        {
            StartCoroutine(player.PlayGameOverFX());
            gameOverText.text = score.getSnakeCount().ToString().PadLeft(2, '0');
            gameOverPanel.SetActive(true);
            gameIsOver = true;
        }
    }
}
