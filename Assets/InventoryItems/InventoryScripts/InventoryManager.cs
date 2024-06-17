using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory inventory;


    //public Inventory mybag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInfromation;
    private void Awake()
    {
        // DontDestroyOnLoad(gameObject);
        if (instance! == null)
            Destroy(this);
        instance = this;

        //inventory = Resources.Load<Inventory>("Inventory");
        foreach (var item in inventory.itemList)
        {
            CreateNewItem(item);
        }
    }
    private void OnEnable()
    {
        instance.itemInfromation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance .itemInfromation .text = itemDescription;
    }


    public static void CreateNewItem(Item item)
    {
        
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.gameObject.transform.localScale = new Vector3 (1,1,1);
    }
    
}
