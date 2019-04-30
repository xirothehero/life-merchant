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

    public GameObject HPtext;

    public Sprite blacksmithImage;

    public Sprite magicianImage;

    public Image buyerImage;

    public Image sellerImage;

    public int qty = 30;


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
            buyerImage.GetComponent<Image>().sprite = blacksmithImage;
            sellerImage.GetComponent<Image>().sprite = blacksmithImage;
        }
        else
        {
            title.GetComponent<Text>().text = "City of Ah-Yi";
            buyText.GetComponent<Text>().text = "Buy from sorceror";
            buyerImage.GetComponent<Image>().sprite = magicianImage;
            sellerImage.GetComponent<Image>().sprite = magicianImage;
        }

        title.GetComponent<FadeIn>().StartFadeIn();
        StoreManager.Get().GenerateStock(qty);
        AudioManager.Get().PlayMusic(AudioManager.MusicClipName.BackgroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        // Title in out
        if(title.GetComponent<FadeIn>().state == FadeIn.State.In)
        {
            title.GetComponent<FadeIn>().StartFadeOut();
        }

        HPtext.GetComponent<Text>().text = Player.Get().health.ToString();
    }

    public void ShowBlacksmith()
    {
        buyPanel.SetActive(true);
        AudioManager.Get().PlaySound(AudioManager.SoundClipName.PanelOpen);
        
    }

    public void ShowMarket()
    {
        sellPanel.SetActive(true);
        AudioManager.Get().PlaySound(AudioManager.SoundClipName.PanelOpen);
    }

    public void LeaveRealm()
    {
        float buyVar = StoreManager.Get().buyVar;

        if (StoreManager.Get().realm == BaseItem.Realm.Physical)
        {
            StoreManager.Get().realm = BaseItem.Realm.Magical;
        }
        else
        {
            StoreManager.Get().realm = BaseItem.Realm.Physical;
        }

        foreach (Item item in Inventory.Get().GetItems())
        {
            // Random cost variance
            if(StoreManager.Get().realm == item.baseItem.realm)
            {
                item.currentCost = (int) (item.GetLowCost() * (1 + Random.Range(-buyVar, buyVar)));
            } else
            {
                item.currentCost = (int) (item.GetHighCost() * (1 + Random.Range(-buyVar, buyVar)));
            }
        }

        StoreManager.Get().ClearStock();
        SceneManager.LoadScene("Combat");
    }
}
