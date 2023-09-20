using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class Score : MonoBehaviour
{
    public Text GoodPercentageDisplay;
    public Text BadPercentageDisplay;
    public Text ScoreText;
    public Text ComboText;
    public Text ComboMultiplierText;
    public float score;
    public float combo;
    public float comboMultiplier;

    void Start()
    {
        SetText();
    }
    void Update()
    {
        if (combo < 5)
        {
            comboMultiplier = 1;
            
        }
        if(combo>5 && combo<10) comboMultiplier= 2;
        if (combo>10 && combo<20) comboMultiplier = 3;
        if (combo>20 && combo<30) comboMultiplier = 4;
        if (combo>30 && combo<40) comboMultiplier = 5;

    }
    public void SubtractScore(int _scoreSubValue)
    {
        combo = 0;
        score-= _scoreSubValue;
        Debug.Log(score.ToString()); 
        SetText();
    }
    public void AddScore(int _scoreAddValue)
    {
        combo++;
        score+= _scoreAddValue * comboMultiplier;
        Debug.Log(score.ToString());
        SetText();
    }

    void SetText()
    {
        ScoreText.text = score.ToString();
        ComboMultiplierText.text = "x " + comboMultiplier.ToString();
        if (combo > 5)
        {
            ComboText.text = "COMBO!" + "\n" + combo.ToString();
        }
        else
        {
            ComboText.text = combo.ToString();
        }

    }



}
