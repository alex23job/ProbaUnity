<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtDown : MonoBehaviour
{
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
        if (other.CompareTag("Player"))
        {
            print("DirtDown : Enter Player");
            TakingDamage td = other.gameObject.GetComponent<TakingDamage>();
            if (td != null)
            {
                td.PlayerDown();
            }
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtDown : MonoBehaviour
{
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
        if (other.CompareTag("Player"))
        {
            print("DirtDown : Enter Player");
            TakingDamage td = other.gameObject.GetComponent<TakingDamage>();
            if (td != null)
            {
                td.PlayerDown();
            }
        }
    }
}
>>>>>>> c370533cebd4cd3cbf580a37a8dd0a4fa6e374fd
