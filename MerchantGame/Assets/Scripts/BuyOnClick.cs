using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyOnClick : MonoBehaviour
{
    public Button buyBtn;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = buyBtn.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick(){
        if (Panel != null){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}
