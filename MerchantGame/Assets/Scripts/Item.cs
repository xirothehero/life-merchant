using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public BaseItem baseItem;
    public int variantId = 0;

    public string GetName()
    {
        string itemName = baseItem.variantNames[variantId] + " " + baseItem.baseName;

        return itemName;
    }

    public int GetLowCost()
    {
        return baseItem.lowCosts[variantId];
    }

    public int GetHighCost()
    {
        return baseItem.highCosts[variantId];
    }

    public Sprite GetSprite()
    {
        return baseItem.variantSprites[variantId];
    }
}
