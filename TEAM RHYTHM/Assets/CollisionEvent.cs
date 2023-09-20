using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Script which contains Invokers to call Events on collisions with objects of different tags.
//The player will take damage from Enemy
//The boss takes damage from the pong ball
//Bullet Objects will be deleted/moved to a repository on collision with void (my skybox)
public class CollisionEvent : MonoBehaviour
{
    public UnityEvent OnPlayerCollided;
    public UnityEvent OnPlayerTriggerEnter;
    public UnityEvent OnPlayerTriggerExit;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPlayerCollided.Invoke();
        }
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            OnPlayerTriggerEnter.Invoke();
            Debug.Log("Enter");
        }

    }
    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            OnPlayerTriggerExit.Invoke();
            Debug.Log("Exit");
        }

    }
}
