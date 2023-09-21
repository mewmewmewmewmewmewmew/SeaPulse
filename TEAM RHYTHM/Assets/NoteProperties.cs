using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
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
    public UnityEvent NoteMash;
    public UnityEvent NoteTimerComplete;
    public UnityEvent SetNoteText;
    private GameObject _score;
    public int noteAddscore;
    public int noteSubscore;
    public bool mashNote;
    public int minMash = 1;
    public int currentMash;
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
    void Mistake()
    {
        NoteMiss.Invoke();
        _score.GetComponent<Score>().SubtractScore(noteSubscore);
    }

    void Mash()
    {
        NoteMash.Invoke();
        _score.GetComponent<Score>().AddScore(noteAddscore);
        currentMash++;

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

            if (numberOfPlayers > 0 && mashNote)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Mash();
                    Debug.Log("MASH!");
                }
            }
            if (elapsedTime >= durationOfNote)
            {
                Debug.Log("I happened");
                if (numberOfPlayers != requiredNumberOfPlayers && !mashNote)
                { 
                    Mistake();
                    Debug.Log("Ooops");
                    
                }
                if (numberOfPlayers == requiredNumberOfPlayers && !mashNote)
                {
                    NoteHit();
                    Debug.Log("Hit!");
                    marked = true;
                }
                if(mashNote)
                {

                    if (currentMash>minMash)
                    {
                        NoteHit();
                    }
                    else 
                    {
                        Mistake();
                    }

                }

            }
            yield return null;
        }

    }

}
