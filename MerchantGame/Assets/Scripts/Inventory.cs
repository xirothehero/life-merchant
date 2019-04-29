using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stores current items
public class Inventory : MonoBehaviour
{
    public List<Item> items;

    public static Inventory Get()
    {
        Inventory inventory = GameObject.FindWithTag("Managers").GetComponent<Inventory>();

        return inventory;
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public Item GetItem(int index)
    {
        if (index > 0 && index < countItems()){
            return items[index];
        }
        return null;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public int countItems(){
        return items.Count;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
