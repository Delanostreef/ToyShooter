using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _pfBullet;
    [SerializeField] private float _bulletForce;
    [SerializeField] private Transform _firePoint;

    [SerializeField] private float _timeBetweenShots;
    private float _timeStamp;


    void Update()
    {
        _firePoint.rotation = Quaternion.Euler(0, 0, transform.rotation.z * -1f);

        if (Input.GetKey(KeyCode.Space) && Time.time >= _timeStamp)
        {
            _timeStamp = _timeBetweenShots + Time.time;

            InstantiateBullet();
        }
    }

    private void InstantiateBullet()
    {
        GameObject bullet = Instantiate(_pfBullet, _firePoint.position, _pfBullet.transform.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(_firePoint.right * _bulletForce, ForceMode.Impulse);
    }
}
