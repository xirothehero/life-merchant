using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

// The view for an item
public class ItemBox : MonoBehaviour
{

    public enum Type { Buy, Sell }

    public Type type;

    public Item item;

    public Image image;
    public Text title;
    public Text description;
    public Text costText;
    public Text atk;
    public Text def;

    public bool selected = false;
    
    public void SetItem(Item it)
    {
        item = it;

        image.sprite = item.GetSprite();
        title.text = item.GetName();
        description.text = item.GetDescription();

        costText.text = item.GetCurrentCost().ToString();

        // TODO atk/def
    }
    
    public void OnClick()
    {
        Color btnColor = GetComponent<Image>().color;

        if (!selected)
        {
            btnColor = Color.cyan;
            StoreManager.Get().SelectItem(item);
        }
        else
        {
            btnColor = Color.white;
            StoreManager.Get().DeselectItem(item);
        }

        GetComponent<Image>().color = btnColor;
        selected = !selected;
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
