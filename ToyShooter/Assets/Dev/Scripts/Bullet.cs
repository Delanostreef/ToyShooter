using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletForce;
    public bool _playerShooting;
    private Score _score;

    private void Start()
    {
        _score = FindObjectOfType<Score>();
    }

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
                Destroy(this.gameObject);
            }
        }

        //als de player shoot
        if (_playerShooting)
        {
            if (other.gameObject.tag == "Enemy")
            {
                _score.ScoreAdder(_score._scoreAmount);

                print(_score._currentScore);

                print("u hit a mf");

                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
