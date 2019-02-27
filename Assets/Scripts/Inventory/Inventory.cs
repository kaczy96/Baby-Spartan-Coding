using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    public delegate void OnItemChange();

    public OnItemChange onItemChangeCallback;
    
    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        if(!item.isDefaultItem)
        items.Add(item);
        if (onItemChangeCallback != null) 
            onItemChangeCallback.Invoke();
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangeCallback != null) 
            onItemChangeCallback.Invoke();
    }
}

