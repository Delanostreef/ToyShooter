using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Manager _manager;
    private int bossesKilled;

    public int health;
    public int numberOfHearts;

    private float _timeElapsed;
    private float _timer;

    [SerializeField] private Vector2 _movementSpeed;

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
        _timeElapsed += Time.deltaTime;

        //_timer = 2f;

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3, 4), transform.position.z);

        if (_timeElapsed >= _timer)
        {
            _timeElapsed = 0;

            _timer = Random.Range(1, 5);

            _movementSpeed *= -1;
        }

        if (transform.position.x >= 6)
        {
            transform.position += new Vector3(_movementSpeed.x * Time.deltaTime, 0, 0);
        }

        transform.position += new Vector3(0, _movementSpeed.y * Time.deltaTime, 0);

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
