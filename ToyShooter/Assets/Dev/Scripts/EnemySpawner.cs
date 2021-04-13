using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies = null;
    [SerializeField] private List<GameObject> _enemyList;
    [SerializeField] private int _maxEnemiesSpawned;
    [SerializeField] private int _enemiesSpawned;

    private void Start()
    {
        //InvokeRepeating("SpawnEnemy", 3f, Random.Range(2, 5));
    }

    private void Update()
    {
        if (_enemyList.Count <= _maxEnemiesSpawned - 1 && _enemiesSpawned <= _maxEnemiesSpawned)
        {
            Invoke("SpawnEnemy", Random.Range(2, 5));
            //InvokeRepeating("SpawnEnemy", 0f, Random.Range(2, 5));
            //CancelInvoke("SpawnEnemy");

            //StartCoroutine(SpawnEnemy(Random.Range(2, 5)));

            _enemiesSpawned++;
        }
        //else if (_enemyList.Count == _maxEnemiesSpawned)
        //{
        //    StopCoroutine("SpawnEnemy");
        //}
    }

    private void SpawnEnemy()
    {
        Vector3 randomSpawnPoint = new Vector3(8f, Random.Range(-4f, 4f), 11);

        GameObject enemy = Instantiate(_enemies[Random.Range(0, _enemies.Length)], randomSpawnPoint, _enemies[Random.Range(0, _enemies.Length)].transform.rotation);

        AddEnemy(enemy);

    }

    //private IEnumerator SpawnEnemy(float timeToSpawn)
    //{
    //    yield return new WaitForSeconds(timeToSpawn);
    //}

    public void AddEnemy(GameObject go)
    {
        _enemyList.Add(go);
    }

    public void RemoveEnemy(GameObject go)
    {
        _enemyList.Remove(go);
    }
}
