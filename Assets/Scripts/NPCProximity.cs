using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCProximity : MonoBehaviour
{
    public bool IsPlayerInRange { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter with: " + other.name);
        if (other.gameObject.tag == "MainCamera")
        {
            IsPlayerInRange = true;
            Debug.Log("Player is in range for assassination.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit with: " + other.name);
        if (other.gameObject.tag == "MainCamera")
        {
            IsPlayerInRange = false;
            Debug.Log("Player is out of assassination range.");
        }
    }
}

