using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TempNoteSpawner : MonoBehaviour
{

    public GameObject projectile;
    public int projectileCount;
    //public Direction direction;
    public bool fire;
    //public Vector3 transformVector;
    public bool isParented;
    public bool isDisplaced;
    public float displaceDistance;
    public float delay;
    public bool randomPosition;
    public void SpawnCircularDisplace(int _projectileCount)
    {
        for (int i = 0; i < _projectileCount; i++)
        {

            float circlePosition = (360f / _projectileCount);
            if (isParented)
            {
                GameObject _projectile = Instantiate(projectile, transform.position, projectile.transform.rotation, transform);
                _projectile.transform.Rotate(0, circlePosition * i, 0);
                if (isDisplaced)
                {
                    _projectile.transform.position = _projectile.transform.position + Quaternion.Euler(0, circlePosition * i, 0) * Vector3.forward * displaceDistance;
                }

            }
            else
            {
                GameObject _projectile = Instantiate(projectile, transform.position, projectile.transform.rotation);
                if (randomPosition)
                {
                    _projectile.transform.position = new Vector3(Random.Range(0, 3) * 10, Random.Range(0, 3) * 10, 0);
                }
                //_projectile.transform.Rotate(0, circlePosition * i, 0);
                
                if (isDisplaced)
                {
                    _projectile.transform.position = Quaternion.Euler(0, circlePosition * i, 0) * Vector3.forward * displaceDistance;
                }
            }

        }

    }
    public void RotateSpawner(int dirNumber)
    {
        switch (dirNumber)
        {
            case 1:
                transform.eulerAngles = new Vector3(0, 0, 90);
                break;
            case 2:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 3:
                transform.eulerAngles = new Vector3(45, 45, 0);
                break;
            case 4:
                transform.eulerAngles = new Vector3(0, 45, 45);
                break;
        }
    }

    /*
    public void CallSpawnCircular(int _projectileCount, Direction _direction )
    {
        SpawnCircular(_projectileCount, _direction);
    }
    */
}
