using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private LevelControl lc;

    private bool isKey = false;
    private string helpNoKey = "Найдите ключ чтобы покинуть подземелье !";

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
            if (isKey)
            {
                if (lc != null) lc.FinishLevel();
            }
            else
            {
                if (lc != null) lc.ViewHelp(helpNoKey);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isKey)
            {

            }
            else
            {
                if (lc != null) lc.ViewHelp(helpNoKey, false);
            }
        }
    }

    public void SetKey()
    {
        isKey = true;
    }
}
