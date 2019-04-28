using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellOnClick : MonoBehaviour
{

    public Button sellBtn;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = sellBtn.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);   
    }

    // Update is called once per frame
    void OnClick()
    {
        if (Panel != null){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}
