using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletForce;
    public bool _playerShooting;


    void Update()
    {
        transform.position += transform.up * _bulletForce * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //als de enemy shoot
        if (!_playerShooting)
        {
            if (other.gameObject.tag == "Player")
            {
                print("u hit yourself smh");
                Destroy(other.gameObject);
            }
        }

        //als de player shoot
        if (_playerShooting)
        {
            if (other.gameObject.tag == "Enemy")
            {
                print("u hit a mf");
                Destroy(other.gameObject);
            }
        }
    }
}
