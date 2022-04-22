using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public Level levelRef;

    private void Awake()
    {
        levelRef = transform.GetComponentInParent<Level>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = levelRef.levelRestart.position;
            other.GetComponent<PlayerController>().NewLevelStart();
        }    
    }
}
