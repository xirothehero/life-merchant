using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithManager : MonoBehaviour
{

    public GameObject title;

    // Start is called before the first frame update
    void Start()
    {
        title.GetComponent<FadeIn>().StartFadeIn();
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
}
