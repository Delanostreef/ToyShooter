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

        if (bossCountDown <= 0)
        {
            SpawnBoss();
            _enemySpawner.enabled = false;
        }

        if (bossCountDown > 0)
        {
            _enemySpawner.enabled = true;
        }
    }

    private void SpawnBoss()
    {
        GameObject boss = Instantiate(_boss, _boss.transform.position, _boss.transform.rotation);
        _enemySpawner.RemoveAllEnemies();
    }
}
