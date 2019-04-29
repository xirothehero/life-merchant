using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Logic relating to the stock of the store
public class StoreManager : MonoBehaviour
{
    
    // Points to inventory instance
    public Inventory inventory;
    // All items available for purchase
    public List<Item> stock;
    // Items selected by the player
    public List<Item> selectedItems;

    public BaseItem.Realm realm;
    
    // Random % randomness
    public float buyVar;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.Get();

        // TODO remove after testing
        GenerateStock(10);
        GetStock();
    }

    public static StoreManager Get()
    {
        StoreManager store = GameObject.FindWithTag("Managers").GetComponent<StoreManager>();

        return store;
    }

    public void SetRealm(BaseItem.Realm r)
    {
        realm = r;
    }

    public void GenerateStock(int qty)
    {
        for(int i = 0; i < qty; i++)
        {
            Item item = ItemCatalog.GetRandomItem();

            // Random cost variance
            if(realm == item.baseItem.realm)
            {
                item.currentCost = (int) (item.GetLowCost() * (1 + Random.Range(-buyVar, buyVar)));
            } else
            {
                item.currentCost = (int) (item.GetHighCost() * (1 + Random.Range(-buyVar, buyVar)));
            }

            stock.Add(item);
        }
    }

    public List<Item> GetStock()
    {
        // foreach(Item it in stock)
        // {
        //     Debug.Log(it.GetName());
        // }
        return stock;
    }

    public void ClearStock()
    {
        stock.Clear();
    }

    public void SelectItem(Item item)
    {
        selectedItems.Add(item);
    }

    public void DeselectItem(Item item)
    {
        selectedItems.Remove(item);
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
    public void Buy()
    {
        foreach (Item item in selectedItems)
        {
            Inventory.Get().AddItem(item);
            stock.Remove(item);
        }

        selectedItems.Clear();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
