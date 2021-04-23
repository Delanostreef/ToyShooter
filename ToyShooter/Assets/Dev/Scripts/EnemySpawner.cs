using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies = null;
    [SerializeField] public List<GameObject> _enemyList;
    [SerializeField] private int _maxEnemiesSpawned;
    [SerializeField] private float _minSpawnTime, _maxSpawnTime;
    private bool _isSpawning = false;

    private void Update()
    {
        if (_enemyList.Count <= _maxEnemiesSpawned && !_isSpawning)
        {
            _isSpawning = true;

            StartCoroutine(SpawnEnemy(Random.Range(_minSpawnTime, _maxSpawnTime)));

        }
    }

    //spawned een enemy tussen een aangegeven tijd
    private IEnumerator SpawnEnemy(float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);
        //print("enemy spawned");

        Vector3 randomSpawnPoint = new Vector3(_enemies[0].transform.position.x, Random.Range(-3.5f, 5.5f), _enemies[0].transform.position.z);

        int index = Random.Range(0, _enemies.Length);
        GameObject enemy = Instantiate(_enemies[index], randomSpawnPoint, _enemies[index].transform.rotation);

        AddEnemy(enemy);

        _isSpawning = false;
    }

    //voegt de enemy toe aan de list
    public void AddEnemy(GameObject go)
    {
        _enemyList.Add(go);
    }

    //haalt de enemy uit de list
    public void RemoveEnemy(GameObject go)
    {
        _enemyList.Remove(go);
    }

    //haalt alle enemies uit de lijst
    public void RemoveAllEnemies()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {
            if (_enemyList[i] != null)
            {
                Destroy(_enemyList[i]);
            }
        }

        _enemyList.Clear();
    }
}
