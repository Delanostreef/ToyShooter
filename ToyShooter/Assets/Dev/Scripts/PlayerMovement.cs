using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 lowerBounds, upperBounds;
    public float speed, tiltAngle;

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        transform.position = new Vector3
        (
        Mathf.Clamp(transform.position.x + (input.x * speed * Time.deltaTime), lowerBounds.x, upperBounds.x),
        Mathf.Clamp(transform.position.y + (input.y * speed * Time.deltaTime), lowerBounds.y, upperBounds.y),
        transform.position.z
        );

        //als je omhoog en omlaag beweegt, tilt je scheepje omlaag en omhoog
        transform.eulerAngles = new Vector3(tiltAngle * Input.GetAxis("Vertical"), 0 ,90);
    }
}
