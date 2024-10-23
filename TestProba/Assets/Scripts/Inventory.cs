using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<CollectedItem> items = new List<CollectedItem>();

    public int Count { get { return items.Count; } }

    public CollectedItem[] GetItems()
    {
        return items.ToArray();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(CollectedItem item)
    {
        bool isNew = true;
        foreach(CollectedItem ci in items)
        {
            if (ci.ID == item.ID)
            {
                ci.ChangeCount(1);
                isNew = false;
                break;
            }
        }
        if (isNew)
        {
            item.ChangeCount(1);
            items.Add(item);
        }
    }

    public CollectedItem GetItem(int id)
    {
        foreach(CollectedItem ci in items)
        {
            if (ci.ID == id)
            {
                return ci;
            }
        }
        return null;
    }

    public bool DecrementItem(int id)
    {
        foreach (CollectedItem ci in items)
        {
            if (ci.ID == id)
            {
                ci.ChangeCount(-1);
                if (ci.Count == 0) items.Remove(ci);
                return true;
            }
        }
        return false;
    }
}


