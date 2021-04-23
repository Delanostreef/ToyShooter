using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _explosionFx;
    [SerializeField] private float _bulletForce;
    public bool playerShooting;
    private Score _score;
    private EnemySpawner _enemySpawner;
    private Manager _manager;
    private InvincibilityPlayer _invincibilityPlayer;

    private float _timer;
    private float _timeSpeed = 5f;
    private bool _invincibleEnabled;

    private void Start()
    {
        _score = FindObjectOfType<Score>();
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        _manager = FindObjectOfType<Manager>();
        _invincibilityPlayer = FindObjectOfType<InvincibilityPlayer>();
    }

    void Update()
    {
        if (playerShooting)
        {
            transform.position += transform.right * _bulletForce * Time.deltaTime;
        }
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

                GameObject explosionFx = Instantiate(_explosionFx, this.transform.position, Quaternion.identity);
                Destroy(explosionFx, 0.5f);

                this.gameObject.SetActive(false);

                if (_invincibilityPlayer._invincibleEnabled == false)
                {
                    playerHealth.health -= 1;
                    _invincibilityPlayer._invincibleEnabled = true;
                }

                if (playerHealth.health <= 0)
                {
                    Destroy(other.gameObject, 0.1f);

                    SceneManager.LoadScene("End Screen");
                }

                if (other.gameObject.tag == "OutOfBounds")
                {
                    if (gameObject.tag == "EnemyBullet")
                    {
                        gameObject.SetActive(false);
                    }
                }

            }
        }

        //als de player shoot
        if (playerShooting)
        {
            transform.position += transform.right * _bulletForce * Time.deltaTime;
            if (other.gameObject.tag == "Enemy")
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();

                enemy.health -= 1;
                GameObject explosion = Instantiate(_explosionFx, this.transform.position, Quaternion.identity);
                Destroy(explosion, 0.5f);

                this.gameObject.SetActive(false);

                if (enemy.health <= 0)
                {
                    _enemySpawner.RemoveEnemy(enemy.gameObject);

                    _manager.bossCountDown -= 1;

                    _score.ScoreAdder(other.gameObject.GetComponent<Enemy>().scoreAmount);

                    Destroy(enemy);
                    Destroy(other.gameObject);

                }
                Destroy(this.gameObject);
            }
        }

        if (other.gameObject.tag == "OutOfBounds")
        {
            this.gameObject.SetActive(false);
        }
    }
}



