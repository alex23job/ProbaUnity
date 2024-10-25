using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampTrigger : MonoBehaviour
{
    [SerializeField] private LevelControl lc;
    [SerializeField] private LampControl lampControl;

    private string help1 = "Пустая керосиновая лампа! Если найти керосин и спички, то можно будет её зажечь ...";
    private string help2 = "Используйте керосин (кликнув по нему в инвентаре),  чтобы заправить лампу !";
    private string help3 = "Используйте спички (кликнув по ним в инвентаре),  чтобы зажечь лампу !";
    private string help4 = "Лампа горит! Можно оглядется вокруг ...";
    private string help5 = "Есть спички, но без керосина лампа гореть не будет!";
    private string help6 = "Лампа заправлена, но без спичек её не зажечь!";
    private bool isFill = false;
    private bool isFire = false;
    private bool isMatches = false;
    private bool isKerosine = false;
    private bool isNotComponent = true;
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
            print($"isKerosine={isKerosine}  isMatches={isMatches}  isFill={isFill}  isFire={isFire}  isNot={isNotComponent}");
            if (lc != null)
            {
                if (isNotComponent) lc.ViewHelp(help1);
                else
                {
                    if (isKerosine && !isFill) lc.ViewHelp(help2);
                    if (isMatches && !isKerosine) lc.ViewHelp(help5);
                    if (!isMatches && isFill) lc.ViewHelp(help6);
                    if (isMatches && isFill && !isFire) lc.ViewHelp(help3);
                    if (isFill && isFire) lc.ViewHelp(help4);
                }
                lc.SelectLocation(4);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lc != null)
            {
                lc.ViewHelp(help1, false);
                lc.SelectLocation(-1);
            }
        }
    }

    public void SetMatches()
    {
        isNotComponent = false;
        isMatches = true;
    }

    public void SetKerosine()
    {
        isNotComponent = false;
        isKerosine = true;
    }

    public void SetFill()
    {
        isNotComponent = false;
        isFill = true;
        if (lc != null)
        {
            if (isMatches) lc.ViewHelp(help3);
            else lc.ViewHelp(help6);
        }
    }

    public void SetFire()
    {
        if (isFill)
        {
            isFire = true;
            lampControl.SetLight();
            if (lc != null) lc.ViewHelp(help4);
        }
    }
}
