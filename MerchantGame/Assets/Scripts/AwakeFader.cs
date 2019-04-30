using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class AwakeFader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().enabled = true;
        GetComponent<FadeIn>().StartFadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<FadeIn>().state == FadeIn.State.Out)
        {
            Destroy(gameObject);
        }
    }
}
