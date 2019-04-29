using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public enum Stage { None, ClickToBegin, ActuallyBegin }

    public Stage stage;

    public GameObject title;
    public GameObject begin;

    public List<GameObject> instructions;

    public GameObject fadeBlack;

    public GameObject spooky;

    // Start is called before the first frame update
    void Start()
    {
        title.GetComponent<FadeIn>().StartFadeIn();
        begin.GetComponent<FadeIn>().StartFadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        if(stage == Stage.None)
        {
            if(begin.GetComponent<FadeIn>().state == FadeIn.State.In)
            {
                if(Input.GetMouseButtonUp(0))
                {
                    foreach(GameObject instr in instructions)
                    {
                        instr.SetActive(true);
                        instr.GetComponent<FadeIn>().StartFadeIn();
                    }
                    title.GetComponent<FadeIn>().StartFadeOut();
                    begin.GetComponent<FadeIn>().StartFadeOut();

                    spooky.SetActive(true);
                    spooky.GetComponent<FadeIn>().StartFadeIn();

                    stage = Stage.ActuallyBegin;
                }
            }
        } else if(stage == Stage.ActuallyBegin)
        {
            if (Input.GetMouseButtonUp(0))
            {
                fadeBlack.SetActive(true);
                fadeBlack.GetComponent<FadeIn>().StartFadeIn();

                foreach (GameObject instr in instructions)
                {
                    instr.SetActive(true);
                    instr.GetComponent<FadeIn>().StartFadeOut();
                }
            }

            if(fadeBlack.GetComponent<FadeIn>().state == FadeIn.State.In)
            {
                GameManager.Get().StartGame();
            }
        }
    }
}
