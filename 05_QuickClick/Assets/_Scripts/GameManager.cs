using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public enum GameStates
    {
        loading,
        inGame,
        gameOver
    }

    public GameStates gameState;
    public List<GameObject> targetPrefabs;
    public float _spawnRate = 1;
    public float spawnRate;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    private int _score;
    private int _lives;
    public Button restartButton;
    public GameObject startPanel;
    private string KEY_MAX_SCORE = "MaxScore";
    private int score
    {
        set
        {
            _score = Mathf.Clamp(value, 0, 999);
        }
        get
        {
            return _score;
        }
    }

    public int lives
    {
        get => _lives;
        set => _lives = Mathf.Clamp(value, 0, 10);
    }

    private void Start()
    {
        MaxScore();
    }

    public void StartGame(int difficulty)
    {
        spawnRate = _spawnRate / difficulty;
        startPanel.gameObject.SetActive(false);
        gameState = GameStates.inGame;
        StartCoroutine(SpawnTarger());
        score = 0;
        lives = 3;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarger()
    {
        while (gameState == GameStates.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        if (score >= 100)
        {
            setLives(1);
            score -= 100;
        }
    }

    public void MaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(KEY_MAX_SCORE,0);
        scoreText.text = "Max Score: " + maxScore;
    }

    public void setLives(int valor)
    {
        lives += valor;
        livesText.text = "Vidas Restantes: " + lives;
        if (lives <= 0)
            GameOver();
    }

    public void GameOver()
    {
        int maxScore = PlayerPrefs.GetInt(KEY_MAX_SCORE,0);
        if(score > maxScore)
            PlayerPrefs.SetInt(KEY_MAX_SCORE,score);
        gameOverText.gameObject.SetActive(true);
        gameState = GameStates.gameOver;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
