using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMatchesTrigger : MonoBehaviour
{
    [SerializeField] private LevelControl lc;
    [SerializeField] private AudioSource effect;
    [SerializeField] private AudioClip tresk;
    [SerializeField] private AudioClip fireBegin;

    private bool isPressedE = false;
    private string helpJug = "Нажмите  < Е >  чтобы взять спички - точно пригодятся !";

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
                print("Entered  << E >> for BoxMatches");
                PlayEffect(1);
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

    public void PlayEffect(int n)
    {
        if (effect != null)
        {
            if (n == 1) effect.clip = tresk;
            if (n == 2) effect.clip = fireBegin;
            effect.Play();
        }
    }
}
