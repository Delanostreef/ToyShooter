using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Manager _manager;
    private int bossesKilled;

    public int health;
    public int numberOfHearts;
    void Start()
    {
        _manager = FindObjectOfType<Manager>();
    }

    void Update()
    {
        Health();
        Behaviour();
        OnDeath();
    }

    private void Health()
    {
        if (health > numberOfHearts)
        {
            health = numberOfHearts;
        }
    }


    private void Behaviour()
    {

    }

    private void OnDeath()
    {
        if (health <= 0)
        {
            bossesKilled += 1;
            _manager.bossCountDown = 25 + (bossesKilled * 5);
            Destroy(this.gameObject);
        }
    }
}
