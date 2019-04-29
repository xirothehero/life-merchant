using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelect : MonoBehaviour
{

    public Button ItemButton;
    public Text ItemText;
    private Item item;

    public bool isBuy;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = ItemButton.GetComponent<Button>();
        btn.onClick.AddListener(ItemOnClick);
        SetInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInfo(){
        Text text = ItemText.GetComponent<Text>();
        string iteminfo = text.text;

        item = ItemCatalog.GetRandomItem();
        
        if(isBuy){
            iteminfo = item.GetName() + "   " + item.GetLowCost();
        } else {
            iteminfo = item.GetName() + "   " + item.GetHighCost();
        }

        text.text = iteminfo;
    }

    void ItemOnClick(){
        Color btnColor = ItemButton.GetComponent<Image>().color;
        if (btnColor == Color.white){
            btnColor = Color.cyan;
        }
        else if (btnColor == Color.cyan){
            btnColor = Color.white;
        }
        ItemButton.GetComponent<Image>().color = btnColor;
    }
}
