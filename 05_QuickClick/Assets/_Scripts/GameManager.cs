using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

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
    public float spawnRate = 1;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    private int _score;
    private int _lives;
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

    // Start is called before the first frame update
    void Start()
    {
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

    public void setLives(int valor)
    {
        lives += valor;
        livesText.text = "Vidas Restantes: " + lives;
        if (lives <= 0)
            GameOver();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameState = GameStates.gameOver;
    }

}
