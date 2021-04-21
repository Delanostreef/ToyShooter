using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _explosionFx;
    [SerializeField] private float _bulletForce;
    public bool playerShooting;
    private Score _score;
    private EnemySpawner _enemySpawner;

    private void Start()
    {
        _score = FindObjectOfType<Score>();
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Update()
    {
        transform.position += transform.up * _bulletForce * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //als de enemy shoot
        if (!playerShooting)
        {
            if (other.gameObject.tag == "Player")
            {
                print("oof");

                Health playerHealth = other.gameObject.GetComponent<Health>();

                playerHealth.health -= 1;

                if (playerHealth.health <= 0)
                {
                    GameObject explosionFx = Instantiate(_explosionFx, this.transform.position, Quaternion.identity);

                    Destroy(explosionFx, 0.5f);

                    Destroy(other.gameObject, 0.1f);
                }
                Destroy(this.gameObject);
            }
        }

        //als de player shoot
        if (playerShooting)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();

                enemy.health -= 1;

                if (enemy.health <= 0)
                {
                    _enemySpawner.RemoveEnemy(enemy.gameObject);

                    GameObject explosionFx = Instantiate(_explosionFx, this.transform.position, Quaternion.identity);

                    _score.ScoreAdder(other.gameObject.GetComponent<Enemy>().scoreAmount);

                    //print(_score.currentScore);

                    Destroy(explosionFx, 0.5f);
                    Destroy(other.gameObject);
                }
                Destroy(this.gameObject);
            }
        }
    }
}
