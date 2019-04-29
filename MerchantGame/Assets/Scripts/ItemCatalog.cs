using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatalog : MonoBehaviour
{

    public List<BaseItem> baseItems;

    public static Item GetRandomItem()
    {
        ItemCatalog catalog = GameObject.FindWithTag("Managers").GetComponent<ItemCatalog>();
        BaseItem baseItem = catalog.baseItems[Random.Range(0, catalog.baseItems.Count)];
        Item item = baseItem.GetRandomVariant();

        return item;
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
