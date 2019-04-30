using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{

    public GameObject deadImg;

    public GameObject black;

    public GameObject text;

    public GameObject managerBlueprint;

    // Start is called before the first frame update
    void Start()
    {


        if (GameObject.FindWithTag("Managers") == null)
        {
            Instantiate(managerBlueprint);
        }

        deadImg.SetActive(true);
        deadImg.GetComponent<FadeIn>().StartFadeIn();
        text.SetActive(true);
        text.GetComponent<FadeIn>().StartFadeIn();

        AudioManager.Get().PlayMusic(AudioManager.MusicClipName.DeathMusic);
    }

    // Update is called once per frame
    void Update()
    {

        if(deadImg.GetComponent<FadeIn>().state == FadeIn.State.In && black.GetComponent<FadeIn>().state == FadeIn.State.Out)
        {
            black.SetActive(true);
            black.GetComponent<FadeIn>().StartFadeIn();
        }

        if (text.GetComponent<FadeIn>().state == FadeIn.State.In)
        {
            text.GetComponent<FadeIn>().StartFadeOut();
        }

        if(black.GetComponent<FadeIn>().state == FadeIn.State.In)
        {
            GameManager.Get().StartMenu();
        }
    }
}
