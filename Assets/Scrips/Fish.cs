using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, speed);
        }

        if (_rb.velocity.y > 0)
        {
            if (angle <=maxAngle)
            {
                angle += 4;

            }
        }
        else if (_rb.velocity.y < 0)
        {
            if (angle >= minAngle)
            {
                angle -= 2;

            }
        }

        //rotasyon g�ncellemsi
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
