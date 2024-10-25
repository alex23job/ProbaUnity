<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtTrigger : MonoBehaviour
{
    [SerializeField] private GameObject boardPrefab;
    [SerializeField] private LevelControl lc;
    [SerializeField] private AudioSource effect;
    private string helpJug = "В яму с грязью можно и провалиться ! Положу-ка я пару досок (кликом в инвентаре) и перейду по ним !";
    bool isKey = false;

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
        if (isKey) return;
        if (other.CompareTag("Player"))
        {
            if (lc != null)
            {
                lc.ViewHelp(helpJug);
                lc.SelectLocation(3);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isKey) return;
        if (other.CompareTag("Player"))
        {
            if (lc != null)
            {
                lc.ViewHelp(helpJug, false);
                lc.SelectLocation(-1);
            }
        }
    }
    public void SetBoard()
    {
        Vector3 posBoard = transform.position;
        posBoard.y += 3;
        posBoard.z -= 1;
        Instantiate(boardPrefab, posBoard, Quaternion.identity);
        posBoard.z += 2;
        Instantiate(boardPrefab, posBoard, Quaternion.identity);
        if (effect != null) effect.Play();
        if (lc != null) lc.ViewHelp(helpJug, false);
        isKey = true;
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtTrigger : MonoBehaviour
{
    [SerializeField] private GameObject boardPrefab;
    [SerializeField] private LevelControl lc;
    [SerializeField] private AudioSource effect;
    private string helpJug = "В яму с грязью можно и провалиться ! Положу-ка я пару досок (кликом в инвентаре) и перейду по ним !";
    bool isKey = false;

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
        if (isKey) return;
        if (other.CompareTag("Player"))
        {
            if (lc != null)
            {
                lc.ViewHelp(helpJug);
                lc.SelectLocation(3);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isKey) return;
        if (other.CompareTag("Player"))
        {
            if (lc != null)
            {
                lc.ViewHelp(helpJug, false);
                lc.SelectLocation(-1);
            }
        }
    }
    public void SetBoard()
    {
        Vector3 posBoard = transform.position;
        posBoard.y += 3;
        posBoard.z -= 1;
        Instantiate(boardPrefab, posBoard, Quaternion.identity);
        posBoard.z += 2;
        Instantiate(boardPrefab, posBoard, Quaternion.identity);
        if (effect != null) effect.Play();
        if (lc != null) lc.ViewHelp(helpJug, false);
        isKey = true;
    }
}
>>>>>>> c370533cebd4cd3cbf580a37a8dd0a4fa6e374fd
