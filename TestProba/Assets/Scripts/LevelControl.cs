using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private UI_Control ui_control;
    [SerializeField] private Inventory inventory;

    [SerializeField] private KeyTrigger keyControl;
    [SerializeField] private DoorTrigger doorControl;
    [SerializeField] private DebrisTrigger debrisControl;
    [SerializeField] private DirtTrigger dirtControl;

    [SerializeField] private TakingDamage td;

    private int currentLocation = -1;
    private float timer = 1f;
    private int second = 300;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            timer = 1f;
            second--;
            ui_control.ViewTime(second);
        }
    }

    public void ViewHelp(string strHelp, bool isView = true)
    {
        ui_control.ViewInfo(strHelp, isView);
    }

    public void ReceivedItem(CollectedItem item)
    {
        inventory.AddItem(item);
        if (item.ID == 1)
        {   //  получен ключ
            doorControl.SetKey();
        }
    }

    public void SelectLocation(int numLocation)
    {   //  -1 - локация не выбрана, 1 - бочка с водой, 2 - куча мусора, 3 - яма с грязью, 4 - керосиновая лампа
        currentLocation = numLocation;
    }

    public void OnItemButtonClick(int num)
    {
        if (currentLocation == -1) return;
        CollectedItem[] items = inventory.GetItems();
        for(int i = 0; i < items.Length; i++)
        {
            if (i == num)
            {
                CollectedItem ci = items[i];
                switch(currentLocation)
                {
                    case 1:
                        if (ci.ID == 2)
                        {
                            ci.ChangeCount(1);
                            ci.GetComponent<JugTrigger>().PlayEffect();
                        }
                        break;
                    case 2:
                        if (ci.ID == 2 && ci.Count == 2)
                        {
                            keyControl.SetKey();
                            debrisControl.SetKey();
                        }
                        break;
                    case 3:
                        if (ci.ID == 5 && ci.Count == 2)
                        {
                            dirtControl.SetBoard();
                            ci.ChangeCount(-2);
                            td.PlayerSetBoard();
                        }
                        break;
                    case 4:
                        break;
                }
            }
        }
    }

    public void FinishLevel()
    {
        ui_control.ViewFinishLevel();
    }

    public void PlayerKilled()
    {
        ui_control.ViewLossPanel();
    }

    public void ViewHP(int hp, int maxHp)
    {
        ui_control.ViewHP(hp, maxHp);
    }
}
