using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public enum State { Out, Fading, In }

    public float waitTime = 0.0f;
    public float duration = 1.0f;
    public State state = State.Out;

    Color ogColor;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Image>() != null)
        {
            ogColor = GetComponent<Image>().color;
        }
        else if (GetComponent<Text>() != null)
        {
            ogColor = GetComponent<Text>().color;
        } else
        {
            Debug.LogError("No Image nor Text component to fade in O:");
        }

        StartFadeIn();
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeInAnimation());
    }

    IEnumerator FadeInAnimation()
    {
        SetColor(new Color(ogColor.r, ogColor.g, ogColor.b, 0));
        state = State.Fading;

        float timePassed = 0.0f;

        while(timePassed <= waitTime)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }

        timePassed = 0.0f;

        while(timePassed <= duration)
        {
            timePassed += Time.deltaTime;
            SetColor(new Color(ogColor.r, ogColor.g, ogColor.b, timePassed/duration * ogColor.a));
            yield return null;
        }

        state = State.In;

        yield return null;
    }

    public void SetColor(Color c)
    {
        if(GetComponent<Image>() != null)
        {
            GetComponent<Image>().color = c;
        } else if(GetComponent<Text>() != null)
        {
            GetComponent<Text>().color = c;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
