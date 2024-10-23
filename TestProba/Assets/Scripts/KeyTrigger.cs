using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    [SerializeField] private LevelControl lc;

    private bool isKey = false;
    private bool isPressedE = false;
    private string helpKey = "Нажмите  < Е >  чтобы взять ключ !";
    private ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        smoke = transform.GetChild(1).GetComponent<ParticleSystem>();
        smoke.Pause();
        transform.gameObject.SetActive(false);
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
            if (isKey)
            {
                if (lc != null) lc.ViewHelp(helpKey);
            }
            else
            {
                if (lc != null) lc.ViewHelp(helpKey);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isKey)
        {
            if (isPressedE)
            {
                print("Entered  << E >>  for Key");
                lc.ViewHelp(helpKey, false);
                lc.ReceivedItem(gameObject.GetComponent<CollectedItem>());
                smoke.Stop();
                transform.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isKey)
            {
                if (lc != null) lc.ViewHelp(helpKey, false);
            }
            else
            {
                if (lc != null) lc.ViewHelp(helpKey, false);
            }
            isPressedE = false;
        }
    }

    public void SetKey()
    {
        transform.gameObject.SetActive(true);
        isKey = true;
        smoke.Play();
    }
}
