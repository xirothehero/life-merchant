using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellManager : MonoBehaviour
{
   // Points to inventory instance
    public Inventory inventory;

    public List<Item> inventoryItems;
    // Items selected by the player
    public List<Item> selectedItems;

    public BaseItem.Realm realm;
    
    // Random % randomness
    public float buyVar;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.Get();
        inventoryItems = Inventory.Get().GetItems();

    }

    public static SellManager Get()
    {
        SellManager selling = GameObject.FindWithTag("Managers").GetComponent<SellManager>();

        return selling;
    }

    public void SetRealm(BaseItem.Realm r)
    {
        realm = r;
    }

    public List<Item> GetInvItems(){
        return inventoryItems;
    }

    public void SelectItem(Item item)
    {
        selectedItems.Add(item);
        //AudioManager.Get().PlaySound(AudioManager.SoundClipName.Select);
    }

    public void DeselectItem(Item item)
    {
        selectedItems.Remove(item);
        //AudioManager.Get().PlaySound(AudioManager.SoundClipName.Deselect);
    }

    public List<Item> GetSelectedItems()
    {
        return selectedItems;
    }

    public int GetSelectedCost()
    {
        int cost = 0;
        foreach(Item item in selectedItems)
        {
            //cost += realm == item.baseItem.realm ? item.GetLowCost() : item.GetHighCost();
            cost += item.currentCost;
        }

        return cost;
    }

    // Move selectedItems to inventory
    public void Sell()
    {
        foreach (Item item in selectedItems)
        {
            inventoryItems.Remove(item);
        }
        Player.Get().AddHealth(GetSelectedCost());
        if(selectedItems.Count != 0){
            AudioManager.Get().PlaySound(AudioManager.SoundClipName.Sell);
        }
            selectedItems.Clear();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
