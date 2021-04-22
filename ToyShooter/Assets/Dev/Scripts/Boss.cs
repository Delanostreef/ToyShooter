using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Manager _manager;
    void Start()
    {
        _manager = FindObjectOfType<Manager>();
    }

    void Update()
    {
        //if (_manager.bossCountDown < 1)
        //{
        //    SpawnBoss();
        //}
        
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
