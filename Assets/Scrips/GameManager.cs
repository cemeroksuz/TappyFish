using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    

     private void Awake()
    {
        //ekran�n sol s�n�r�
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
