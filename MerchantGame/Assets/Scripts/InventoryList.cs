using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    public enum Type { Buy, Sell }

    public Type type;

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

        // Build from Inventory list
        foreach(Item item in SellManager.Get().GetInvItems())
        {
            //Debug.Log(item.GetName());

            GameObject itemBox = Instantiate(listItemTemplate);
            itemBox.GetComponent<ItemBox>().type = ItemBox.Type.Sell;
            itemBox.GetComponent<ItemBox>().SetItem(item);
            itemBox.transform.SetParent(listParent.transform, false);

            itemBoxes.Add(itemBox);
        }
    }

    public void Sell()
    {
        SellManager.Get().Sell();
        // Rebuilds display
        Display();
    }
}
