using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Score")]
    public int scoreAmount;

    [Header("Health")]
    public int health;
    public int numberOfHearts;

    [Header("Movement")]
    [SerializeField] private float _movementSpeed;
    public float dirTimer;
    private int location;

    private EnemySpawner enemySpawner;

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }


    void Update()
    {
        EnemyHealth();
        RandomDirection();
        EnemyMovement();
        DeSpawn();
    }

    private void EnemyHealth()
    {
        if (health >= numberOfHearts)
        {
            numberOfHearts = health;
        }
    }

    private void RandomDirection()
    {
        if (dirTimer > 0)
        {
            dirTimer = dirTimer - 1 * Time.deltaTime;
        }
        if (dirTimer <= 0)
        {
            location = Random.Range(1, -2);
            dirTimer = 2;
        }
        if (transform.position.y > 4)
        {
            location = -1;
        }
        if (transform.position.y < -4)
        {
            location = 1;
        }
    }

    private void EnemyMovement()
    {
        transform.position += new Vector3(-_movementSpeed * Time.deltaTime, location * Time.deltaTime / 2, 0);
    }

    private void DeSpawn()
    {
        if (this.transform.position.x <= -15)
        {
            enemySpawner.RemoveEnemy(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
