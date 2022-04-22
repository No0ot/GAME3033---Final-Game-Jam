using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    bool useOnce = false;
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            if (!useOnce)
            {
                useOnce = true;
                Debug.Log("ETNER");
                GameManager.instance.GotoNextLevel();
            }
        }
        
    }
}
