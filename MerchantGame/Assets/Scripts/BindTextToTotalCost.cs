using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BindTextToTotalCost : MonoBehaviour
{

    public Text text;

    public enum Type { Buy, Sell };

    public Type type;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }



    // Update is called once per frame
    // Need to get value from StoreManager on buy panel, from SellManager for sell panel
    void Update()
    {
        if (type == Type.Buy)
        {
            text.text = StoreManager.Get().GetSelectedCost().ToString();
        }
        else {
            text.text = SellManager.Get().GetSelectedCost().ToString();
        }
    }
}
