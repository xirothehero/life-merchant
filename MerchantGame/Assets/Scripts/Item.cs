using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{

    public BaseItem baseItem;
    public int variantId = 0;

    public int currentCost;

    public string GetName()
    {
        string itemName = baseItem.variantNames[variantId] + " " + baseItem.baseName;

        return itemName;
    }

    public string GetDescription()
    {
        string desc = baseItem.descriptions[variantId];
        return desc;
    }

    public void SetCost(int i)
    {
        currentCost = i;
    }

    public int GetCurrentCost()
    {
        return currentCost;
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
        return baseItem.sprites[variantId];
    }
}
