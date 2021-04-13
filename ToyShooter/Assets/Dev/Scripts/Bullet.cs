using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _explosionFx;
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
                print("oof");

                Health playerHealth = other.gameObject.GetComponent<Health>();

                playerHealth.health -= 1;

                if (playerHealth.health == 0)
                {
                    Destroy(other.gameObject);
                }
                Destroy(this.gameObject);
            }
        }

        //als de player shoot
        if (_playerShooting)
        {
            if (other.gameObject.tag == "Enemy")
            {
                _score.ScoreAdder(other.gameObject.GetComponent<Enemy>()._scoreAmount);

                print(_score._currentScore);

                GameObject explosionFx = Instantiate(_explosionFx, this.transform.position, Quaternion.identity);

                Destroy(explosionFx, 0.5f);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
