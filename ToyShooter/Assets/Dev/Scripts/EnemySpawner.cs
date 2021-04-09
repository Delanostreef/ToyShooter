using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy = null;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 3f, Random.Range(2, 5));
    }

    private void SpawnEnemy()
    {
        Vector3 randomSpawnPoint = new Vector2(8f, Random.Range(-4f, 4f));

        Instantiate(enemy, randomSpawnPoint, enemy.transform.rotation);
    }
}
