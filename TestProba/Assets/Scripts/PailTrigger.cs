using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PailTrigger : MonoBehaviour
{
    [SerializeField] private LevelControl lc;

    private string helpJug = "Используйте кувшин (кликнув по нему в инвентаре),  чтобы набрать воды !";
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
            if (lc != null)
            {
                lc.ViewHelp(helpJug);
                lc.SelectLocation(1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lc != null)
            {
                lc.ViewHelp(helpJug, false);
                lc.SelectLocation(-1);
            }
        }
    }
}
