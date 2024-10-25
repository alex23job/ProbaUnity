using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTriggers : MonoBehaviour
{
    [SerializeField] private BatControl bc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print($"BatTrigger Enter {other.name}");
            if (bc != null) bc.ChangeFlight(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print($"BatTrigger Exit {other.name}");
            if (bc != null) bc.ChangeFlight(false);
        }
    }
}
