using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWidht;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        groundWidht = box.size.x;
        
    }


    void Update()
    {
        //sola sürekli hareket
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        //ground nesnesini hareket anýnda ekrandan çýktýðýnda baþa alma
        if (transform.position.x <= -groundWidht)
        {
            transform.position = new Vector2(transform.position.x + 2 * groundWidht, transform.position.y);
        }
     }
}
