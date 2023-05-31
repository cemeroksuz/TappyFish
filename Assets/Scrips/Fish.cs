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
    public Score score;
    bool touchedGround;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;

    public GameManager gameManager;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        FishSwim();          
    }

    private void FixedUpdate()
    {
        FishRotation();
    }

    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            _rb.velocity = Vector2.zero; 
            _rb.velocity = new Vector2(_rb.velocity.x, speed);
        }
    }
    void FishRotation()
    {
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;

            }
        }
        else if (_rb.velocity.y < 0)
        {
            if (angle >= minAngle)
            {
                angle = angle - 2;

            }
        }
        //rotasyon güncellemsi
        if (touchedGround == false)
        {           
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //engeller arasýnda oluþturtulan collider içinden geçildiðinde skor takibi
        if (collision.CompareTag("Obstacle"))
        {
            score.Scored();
        }
        else if (collision.CompareTag("Column"))
        {
            //game over
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                //game over
                gameManager.GameOver();
                GameOver();
            }
            
        }
    }

    void GameOver()
    {
        touchedGround = true;
        sp.sprite = fishDied; // oyun bittiinde balýðýn bir pozisyonda kamlasý (kuyruk sallama animasyonu durdurulmasý)
        anim.enabled = false; // animasyonun durdurulmasý
        transform.rotation = Quaternion.Euler(0, 0, -90); //oyun bittiðinde balýk baþ aþaðý bakacak
    }

}
