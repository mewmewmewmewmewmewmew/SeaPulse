using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class NoteProperties : MonoBehaviour
{
    float duration = 2f;
    public int requiredNumberOfPlayers;
    public int numberOfPlayers;
    public float durationOfNote = 1f;
    public bool marked;
    public UnityEvent OnStart;
    public UnityEvent NoteKill;
    public UnityEvent NoteMiss;
    public UnityEvent NoteTimerComplete;
    public UnityEvent SetNoteText;
    private GameObject _score;
    public int noteAddscore;
    public int noteSubscore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NoteTimer());
        SetNoteText.Invoke();
        Debug.Log("I started note timer");
        OnStart.Invoke();
        _score = GameObject.Find("Score");

    }

    // Update is called once per frame
    void Update()
    {


    }

    void NoteHit()
    {
        NoteKill.Invoke();
        _score.GetComponent<Score>().AddScore(noteAddscore);
    }
    void mistake()
    {
        NoteMiss.Invoke();
        _score.GetComponent<Score>().SubtractScore(noteSubscore);
    }

    public void PlayerOverlapping()
    {
        numberOfPlayers++;
        Debug.Log("PlayerEnter");
        Debug.Log(numberOfPlayers.ToString());
    }
    public void PlayerLeave() 
    {
        numberOfPlayers-=1;
        Debug.Log("PlayerLeave");
        Debug.Log(numberOfPlayers.ToString());
    }

    IEnumerator NoteTimer()
    {
        float elapsedTime = 0f;
        while (elapsedTime < durationOfNote+1f)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= durationOfNote)
            {
                Debug.Log("I happened");
                if (numberOfPlayers != requiredNumberOfPlayers)
                { 
                    mistake();
                    Debug.Log("Ooops");
                    
                }
                if (numberOfPlayers == requiredNumberOfPlayers)
                {
                    NoteHit();
                    Debug.Log("Hit!");
                    marked = true;
                }
            }
            yield return null;
        }

    }

}
