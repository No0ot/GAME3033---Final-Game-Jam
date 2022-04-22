using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public LockDoor door;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            door.OpenGate();
            Destroy(gameObject);
        }
    }
}
