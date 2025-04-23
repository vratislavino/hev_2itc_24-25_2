using System;
using UnityEngine;

public class ShoterEnemySpawner : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    [SerializeField]
    private ShooterEnemy prefab;

    private int score = 0;
    private ShooterEnemy currentEnemy;

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        currentEnemy = Instantiate(prefab, transform.position, Quaternion.identity);
        currentEnemy.EnemyDestroyed += OnEnemyDestroyed;
    }

    private void OnEnemyDestroyed()
    {
        score++;
        ScoreChanged?.Invoke(score);
        currentEnemy.EnemyDestroyed -= OnEnemyDestroyed;
        SpawnEnemy();
    }
}
