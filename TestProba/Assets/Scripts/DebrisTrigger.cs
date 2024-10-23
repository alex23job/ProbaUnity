using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisTrigger : MonoBehaviour
{
    [SerializeField] private LevelControl lc;
    [SerializeField] private AudioSource effect;

    private bool isKey = false;
    private string helpSmoke = "Залейте мусор водой ! Используйте кувшин с водой из инвентаря (кликнув по нему) ...";
    private ParticleSystem smoke;

    // Start is called before the first frame update
    void Start()
    {
        smoke = transform.GetChild(1).GetComponent<ParticleSystem>();
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

            }
            else
            {
                if (lc != null) lc.ViewHelp(helpSmoke);
            }
            if (lc != null) lc.SelectLocation(2);
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
                if (lc != null) lc.ViewHelp(helpSmoke, false);
            }
            if (lc != null) lc.SelectLocation(-1);
        }
    }

    public void SetKey()
    {
        if (effect != null) effect.Play();
        isKey = true;
        smoke.Stop();
    }
}
