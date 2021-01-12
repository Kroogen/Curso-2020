using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targetPrefabs;
    public float spawnRate = 1;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    private int _score;
    private int _lives;
    private bool gameOver;
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
        StartCoroutine(SpawnTarger());
        score = 0;
        lives = 3;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        gameOver = false;
    }

    IEnumerator SpawnTarger()
    {
        while (!gameOver)
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
        gameOver = true;
    }

}
