using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
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
    public UnityEvent OnComboStart;
    public UnityEvent OnComboEnd;
    public int noteCounter;

    void Start()
    {
        SetText();
    }
    void Update()
    {
        if (combo < 5)
        {
            comboMultiplier = 1;
            Debug.Log(noteCounter / score);
        }
        if(combo>5 && combo<10) comboMultiplier= 2;
        if (combo>10 && combo<20) comboMultiplier = 3;
        if (combo>20 && combo<30) comboMultiplier = 4;
        if (combo>30 && combo<40) comboMultiplier = 5;

        if(noteCounter>600 && (noteCounter/(score+1))<1)
        {
            SceneManager.LoadScene("GameOver 1");
        }

    }
    public void SubtractScore(int _scoreSubValue)
    {
        combo = 0;
        score-= _scoreSubValue;
        Debug.Log(score.ToString()); 
        SetText();
        OnComboEnd.Invoke();
        noteCounter++;
    }
    public void AddScore(int _scoreAddValue)
    {
        combo++;
        score+= _scoreAddValue * comboMultiplier;
        Debug.Log(score.ToString());
        SetText();
        noteCounter++;
    }

    void SetText()
    {
        ScoreText.text = score.ToString();
        ComboMultiplierText.text = "x " + comboMultiplier.ToString();
        if (combo > 5)
        {
            ComboText.text = "COMBO!" + "\n" + combo.ToString();
            OnComboStart.Invoke();
        }
        else
        {
            ComboText.text = "";
        }

    }



}
