using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPlayer : MonoBehaviour
{
    private float _timer;
    private float _timeSpeed = 0.5f;
    public bool _invincibleEnabled;

    private void Update()
    {
        if (_invincibleEnabled == true)
        {
            _timer += Time.deltaTime;

            if (_timer >= _timeSpeed)
            {
                _timer = 0;
                _invincibleEnabled = false;
                print("bruh");
            }
        }

        print(_invincibleEnabled);

    }
}
