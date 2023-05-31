using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //eklenmesi gerekir (text nesneleri için)

public class Score : MonoBehaviour
{

    int score;
    int highScore;
    Text scoreText;
    public Text panelScore;
    public Text panelHighScore;

    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();   
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        highScore = PlayerPrefs.GetInt("highscore");//yüksek skorun start ile getirilmesi
        panelHighScore.text = highScore.ToString();
    }
    public void Scored() 
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore",highScore);  //yüksek skoru tutmak için player prefs kullanýyoruz (veritabanýna gerek kalmaz)
        } 

    }
    
    void Update()
    {
        
    }
}
