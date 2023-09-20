using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//This script is a coroutine which allows me to invoke an event for _repetitions repititions
public class RepeatComponent : MonoBehaviour
{
    
    int repetitions;
    public UnityEvent Repeat;
    [SerializeField] private float myDelay = 0.5f;
    public IEnumerator Repeating(int _repetitions)
    {
        WaitForSeconds wait = new WaitForSeconds(myDelay);
        for (int i = 0; i < _repetitions ; i++)
        {
            Repeat.Invoke();
            yield return wait;
        }

    }
    // ...
    public void startRepeat(int _repetitions)
    {
        StartCoroutine(Repeating(_repetitions));
    }
    /*
    // Start is called before the first frame update
    void Repeater(int _repetitions)
    {
        for (int i = 0; i < repetitions; i++)
        {
            Repeat.Invoke();
        }
    }
    */
}
