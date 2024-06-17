using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Inventory",menuName ="Inventory/New Inventory")]
public class Inventory :ScriptableObject 
{ 
    public List<Item> itemList = new List<Item>();
   
    public void AddItem(Item item)
    {
        itemList .Add(item);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }
}
