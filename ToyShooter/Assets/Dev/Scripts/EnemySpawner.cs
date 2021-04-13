using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies = null;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 3f, Random.Range(2, 5));
    }

    private void SpawnEnemy()
    {
        Vector3 randomSpawnPoint = new Vector3(8f, Random.Range(-4f, 4f), 11);

        Instantiate(enemies[Random.Range(0, enemies.Length)], randomSpawnPoint, enemies[Random.Range(0, enemies.Length)].transform.rotation);
    }
}
