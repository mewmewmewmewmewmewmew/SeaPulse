using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows me to fill in 3 lists of projectile waves, and to fill them with objects.
//In the future, I will make it hold a single list and use several copies of the same script with different game objects.
//This way, I will be able to use my Timer and GameStart systems to call however many lists of objects I want.
//This script also has a built in spawner to instantiate the wave, however I will decouple this in the future.
public class WavesList : MonoBehaviour
{
    //Level Design
    public List<GameObject> ProjectileWave = new List<GameObject>();
    List<GameObject> CurrentProjectileWave = new List<GameObject>();
    float timer = 0f;
    int projectileListIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        CurrentProjectileWave = ProjectileWave;
    }

    // Update is used to test spawning. Called once every 5 seconds.
    /*void Update()
    {
        
        timer += Time.deltaTime;
        
        if (timer >= 5)
        {
            SpawnObjects(CurrentProjectileWave);
            Debug.Log(timer);
            timer = 0f;
        }
        
    }*/
    public void CallWaves()
    {
        { 
            SpawnObjects(CurrentProjectileWave);
            Debug.Log(timer);
        }
        
    }
    //spawns objects in place. Can create a fun result if all objects have collisons on. This sends them out in a random feeling spread
    void SpawnObjects(List <GameObject> _ProjectileWave)
    {
        foreach (var Projectile in _ProjectileWave)
        {
            Instantiate(Projectile,transform.position,Quaternion.identity);
        }
    }
   //first attempt at making a circle spawner. The b
    void SpawnObjectsCircle(List <GameObject> _ProjectileWave)
    { 
        for(int i  =0; i <_ProjectileWave.Count; i++)
        {
            float circlePosition = (360/_ProjectileWave.Count);
            GameObject _projectile = Instantiate(_ProjectileWave[i]);
            _projectile.transform.RotateAround(new Vector3(0,0,0), _projectile.transform.up, circlePosition*i);
        }
    }
}
