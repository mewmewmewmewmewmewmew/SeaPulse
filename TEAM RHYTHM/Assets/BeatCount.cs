using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCount : MonoBehaviour
{
    public List<GameObject> Spawnlist = new List<GameObject>();
    public int totalBeatCount;
    public int currentBeatCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToBeat()
    {
        currentBeatCount++;
        if (Spawnlist != null && Spawnlist.Count>-1)
        {
            GameObject _projectile = Instantiate(Spawnlist[currentBeatCount - 1]);
            _projectile.transform.position= Vector3.zero;
        }
    }

}
