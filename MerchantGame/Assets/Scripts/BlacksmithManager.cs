using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithManager : MonoBehaviour
{

    public GameObject title;

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
}
