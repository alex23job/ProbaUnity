using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedItem : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private string itemName;
    [SerializeField] private int id;

    private int count = 0;
    public Sprite ItemSprite { get { return sprite; } }
    public int Count { get { return count; } }
    public int ID { get { return id; } }
    public string ItemName { get { return itemName; } }

    public CollectedItem() { }
    public CollectedItem(CollectedItem it)
    {
        sprite = it.ItemSprite;
        id = it.ID;
        itemName = ItemName;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCount(int cnt)
    {
        int tmp = count + cnt;
        if (tmp >= 0) count += cnt;
        else count = 0;
    }
}
