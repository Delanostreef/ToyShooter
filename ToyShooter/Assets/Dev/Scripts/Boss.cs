using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Enemies Before Boss Spawns")]
    public int bossCountDown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bossCountDown <= 1)
        {
            SpawnBoss();
        }
        
    }

    private void SpawnBoss()
    {

    }

    private void Behaviour()
    {

    }

    private void OnDeath()
    {
         
    }
}
