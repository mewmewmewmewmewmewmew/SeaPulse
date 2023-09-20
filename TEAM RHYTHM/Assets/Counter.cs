using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public Text desiredText;
    public string typeOfCounter;
    int counter;
    public int counterStart;
    private void Start()
    {
        counter = counterStart;
    }
    public void AddToCounter(int countSum)
    {
        counter += countSum;
        desiredText.text = counter.ToString(); 
    }
}
