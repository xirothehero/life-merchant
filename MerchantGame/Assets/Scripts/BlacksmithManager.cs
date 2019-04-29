using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlacksmithManager : MonoBehaviour
{

    public GameObject title;

    public GameObject buyText;

    public GameObject managerBlueprint;

    public GameObject buyPanel;
    public GameObject sellPanel;


    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindWithTag("Managers") == null)
        {
            Instantiate(managerBlueprint);
        }

        if (StoreManager.Get().realm == BaseItem.Realm.Physical)
        {
            title.GetComponent<Text>().text = "City of Akk-Ii";
            buyText.GetComponent<Text>().text = "Buy from blacksmith";
        }
        else
        {
            title.GetComponent<Text>().text = "City of Ah-Yi";
            buyText.GetComponent<Text>().text = "Buy from sorceror";
        }

        title.GetComponent<FadeIn>().StartFadeIn();

        StoreManager.Get().GenerateStock(10);
    }

    // Update is called once per frame
    void Update()
    {
        // Title in out
        if(title.GetComponent<FadeIn>().state == FadeIn.State.In)
        {
            title.GetComponent<FadeIn>().StartFadeOut();
        }
    }

    public void ShowBlacksmith()
    {
        buyPanel.SetActive(true);
        
    }

    public void ShowMarket()
    {
        sellPanel.SetActive(true);
    }

    public void LeaveRealm()
    {
        if (StoreManager.Get().realm == BaseItem.Realm.Physical)
        {
            StoreManager.Get().realm = BaseItem.Realm.Magical;
        }
        else
        {
            StoreManager.Get().realm = BaseItem.Realm.Physical;
        }

        StoreManager.Get().ClearStock();
        SceneManager.LoadScene("Combat");
    }
}
