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
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarger());
        score = 0;
        UpdateScore(0);
    }

    IEnumerator SpawnTarger()
    {
        while (true)
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
    }

}
