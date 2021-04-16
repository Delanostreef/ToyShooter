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

    void Start()
    {

    }


    void Update()
    {
        EnemyHealth();
        EnemyMovement();
    }

    private void EnemyHealth()
    {
        if (health >= numberOfHearts)
        {
            numberOfHearts = health;
        }
    }

    private void EnemyMovement()
    {
        transform.position += new Vector3(-_movementSpeed * Time.deltaTime, 0, 0);
    }
}
