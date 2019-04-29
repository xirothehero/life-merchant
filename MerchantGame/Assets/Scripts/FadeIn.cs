using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public enum State { Out, Fading, In }

    public float inWaitTime = 0.0f;
    public float inDuration = 1.0f;
    public float outWaitTime = 0.0f;
    public float outDuration = 1.0f;
    public State state = State.In;

    public Color ogColor;

    void Awake()
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
    }

    public void StartFadeIn()
    {
        StartCoroutine(FadeInAnimation());
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOutAnimation());
    }

    IEnumerator FadeInAnimation()
    {
        Debug.Log("fadein");
        SetColor(new Color(ogColor.r, ogColor.g, ogColor.b, 0));
        state = State.Fading;

        float timePassed = 0.0f;

        while(timePassed <= inWaitTime)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }

        timePassed = 0.0f;

        while(timePassed <= inDuration)
        {
            timePassed += Time.deltaTime;
            SetColor(new Color(ogColor.r, ogColor.g, ogColor.b, timePassed/inDuration * ogColor.a));
            yield return null;
        }

        state = State.In;

        yield return null;
    }

    IEnumerator FadeOutAnimation()
    {
        SetColor(ogColor);
        state = State.Fading;

        float timePassed = 0.0f;

        while (timePassed <= outWaitTime)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }

        timePassed = 0.0f;

        while (timePassed <= outDuration)
        {
            timePassed += Time.deltaTime;
            SetColor(new Color(ogColor.r, ogColor.g, ogColor.b, (1 - timePassed / outDuration) * ogColor.a));
            yield return null;
        }

        state = State.Out;

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
