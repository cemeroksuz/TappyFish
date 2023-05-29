using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWidht;
    float obstacleWidth;

    void Start()
    {
        //ground nesnesi tag kontrol�
        if (gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidht = box.size.x;
        }


        //engellerin yeniden ba�a getirilmesi
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x; 
        }

       
        
    }


    void Update()
    {
        //sola s�rekli hareket
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (gameObject.CompareTag("Ground"))
        {
            //ground nesnesini hareket an�nda ekrandan ��kt���nda ba�a alma
            if (transform.position.x <= -groundWidht)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidht, transform.position.y);
            }
        }

       
        

        
     }
}
