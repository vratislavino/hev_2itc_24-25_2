using System;
using UnityEngine;

public class RPSEnemySpawner : MonoBehaviour
{
    [SerializeField]
    private int count;

    [SerializeField]
    private GameObject enemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies(count);
    }

    private void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GetRandomPosition();
        var enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        enemy.transform.parent = transform;
    }

    private Vector3 GetRandomPosition()
    {
        var pos = new Vector3(
            UnityEngine.Random.Range(0f, 100f),
            100f,
        UnityEngine.Random.Range(0f, 100f));

        if(Physics.Raycast(pos, Vector3.down, out RaycastHit hit, 105f))
        {
            if(hit.collider.gameObject.name.Contains("Terrain"))
            {
                return hit.point;
            } else
            {
                return GetRandomPosition();
            }
        }
        return GetRandomPosition(); 
    }
}
