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

    public Color selectColor;
    
    public void SetItem(Item it)
    {
        item = it;

        image.sprite = item.GetSprite();
        title.text = item.GetName();
        description.text = item.GetDescription();

        costText.text = item.GetCurrentCost().ToString();

        // TODO atk/def
        List<BaseItem.Effect> eff_list = item.baseItem.effects;
        foreach(BaseItem.Effect effect in eff_list){
            if (effect.type == BaseItem.Effect.Type.Attack){
                atk.text = effect.effectValues[item.variantId].ToString();
            }
            if (effect.type == BaseItem.Effect.Type.Defense){
                def.text = effect.effectValues[item.variantId].ToString();
            }
        }
    }
    
    public void OnClick()
    {
        Color btnColor = GetComponent<Image>().color;

        if (!selected)
        {
            btnColor = selectColor;
            if (type == Type.Buy){
                StoreManager.Get().SelectItem(item);
            }
            else{
                SellManager.Get().SelectItem(item);
            }
        }
        else
        {
            btnColor = Color.white;
            if (type == Type.Buy){
                StoreManager.Get().DeselectItem(item);
            }
            else {
                SellManager.Get().DeselectItem(item);
            }
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
