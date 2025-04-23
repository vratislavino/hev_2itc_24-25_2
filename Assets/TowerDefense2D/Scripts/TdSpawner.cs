using System.Collections;
using UnityEngine;

public class TdSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private TdEnemy prefab;

    [SerializeField]
    private float spawnInterval = 2f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());    
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
