using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTrigger : MonoBehaviour
{
    [SerializeField] private LevelControl lc;

    private bool isPressedE = false;
    private string helpJug = "Нажмите  < Е >  чтобы взять дневник !";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPressedE = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPressedE = false;
            if (lc != null) lc.ViewHelp(helpJug);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isPressedE)
            {
                print("Entered  << E >> for BookLog");
                lc.ViewHelp(helpJug, false);
                lc.ReceivedItem(gameObject.GetComponent<CollectedItem>());
                transform.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lc != null) lc.ViewHelp(helpJug, false);
            isPressedE = false;
        }
    }
}
