using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// View controller
public class ItemList : MonoBehaviour
{

    public GameObject listItemTemplate;

    public List<GameObject> itemBoxes;

    public GameObject listParent;

    // Start is called before the first frame update
    void Start()
    {
        Display();
    }

    public void Display()
    {
        // Clear current list
        foreach(GameObject box in itemBoxes)
        {
            Destroy(box);
        }

        // Build from StoreManager stock
        foreach(Item item in StoreManager.Get().GetStock())
        {
            GameObject itemBox = Instantiate(listItemTemplate);
            itemBox.GetComponent<ItemBox>().SetItem(item);
            itemBox.transform.SetParent(listParent.transform, false);

            itemBoxes.Add(itemBox);        }
    }

    public void Buy()
    {
        StoreManager.Get().Buy();
        // Rebuilds display
        Display();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
