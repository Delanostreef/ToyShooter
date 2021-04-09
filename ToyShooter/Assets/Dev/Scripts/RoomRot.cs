using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRot : MonoBehaviour
{
    private float Rotate;
    public float Speed = 0.1f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Rotate = Time.deltaTime * Speed;
        transform.Rotate(0, Rotate, 0);
    }
}
