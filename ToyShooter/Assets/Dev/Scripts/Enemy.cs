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

    void Start()
    {

    }


    void Update()
    {
        EnemyHealth();
    }

    private void EnemyHealth()
    {
        if (health >= numberOfHearts)
        {
            numberOfHearts = health;
        }
    }
}
