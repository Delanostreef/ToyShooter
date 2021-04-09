using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletForce;


    void Update()
    {
        transform.position += transform.up * _bulletForce * Time.deltaTime;
    }
}
