using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTriggers : MonoBehaviour
{
    [SerializeField] private BatControl bc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print($"BatTrigger Enter {other.name}");
        if (other.CompareTag("Player"))
        {
            if (bc != null) bc.ChangeFlight(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print($"BatTrigger Exit {other.name}");
        if (other.CompareTag("Player"))
        {
            if (bc != null) bc.ChangeFlight(false);
        }
    }
}
