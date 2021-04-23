using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    [Header("Enemies Before Boss Spawns")]
    public int bossCountDown;


    [Header("Boss")]
    [SerializeField] private GameObject _boss;
    [SerializeField] private EnemySpawner _enemySpawner;

    [Header("Text")]
    [SerializeField]
    private TextMeshProUGUI bossSpawn;

    void Update()
    {
        bossSpawn.text = ("Boss In: " + bossCountDown);

        if (bossCountDown <= 0 && _enemySpawner.enabled == true)
        {
            SpawnBoss();
            print("disabled");
        }

        if (bossCountDown > 0)
        {
            _enemySpawner.enabled = true;
            print("enabled");
        }
    }

    private void SpawnBoss()
    {
        Instantiate(_boss, new Vector3(16, 0, 0), _boss.transform.rotation);
        _enemySpawner.enabled = false;
        _enemySpawner.RemoveAllEnemies();
    }
}
