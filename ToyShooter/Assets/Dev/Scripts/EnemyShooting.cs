using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private float _bulletVel;

    [SerializeField]
    List<Transform> bulletTransforms = new List<Transform>();

    ObjectPooler objectPooler;

    private void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
        objectPooler = ObjectPooler.Instance;
    }

    private void Fire()
    {
        for (int i = 0; i < bulletTransforms.Count; i++)
        {
            GameObject go = objectPooler.SpawnFromPool("Bullet", bulletTransforms[i].position, bulletTransforms[i].rotation);

            go.GetComponent<Rigidbody>().velocity = Vector3.zero;
            go.GetComponent<Rigidbody>().AddForce(bulletTransforms[i].up * _bulletVel);
        }
    }
}
