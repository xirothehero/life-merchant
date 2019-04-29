using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase : MonoBehaviour
{
    public string title;
    public enum EventType { Custom, Wait, Show, Hide, Dialogue }

    public EventType eventType;

    public float waitTime;
    public GameObject target;
    private TW_MultiStrings_Regular words;

    public bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Dialogue controls
        if (!done && eventType == EventType.Dialogue && target!= null && target.activeInHierarchy && Input.GetKeyDown("space"))
        {
            if (!words.StringDone())
            {
                words.SkipTypewriter();
            }
            else if (words.AllDone())
            {
                target.SetActive(false);
                done = true;
            }
            else
            {
                words.NextString();
            }
        }
    }

    public virtual void Trigger()
    {
        done = false;
        StartCoroutine(DelayAction());
    }

    public void DoAction()
    {
        switch (eventType)
        {
            case EventType.Wait:
                done = true;
                break;

            case EventType.Show:
                target.GetComponent<SpriteRenderer>().enabled = true;
                done = true;
                break;

            case EventType.Hide:
                Debug.Log("hide");
                target.GetComponent<SpriteRenderer>().enabled = false;
                done = true;
                break;

            case EventType.Dialogue:
                target.SetActive(true);
                words = target.GetComponentInChildren<TW_MultiStrings_Regular>();
                words.StartTypewriter();
                break;

            default:
                break;
        }
    }

    IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(waitTime);
        DoAction();
    }

    public bool Done()
    {
        return done;
    }

    // Waiting OBSOLETE
    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(waitTime);
        done = true;
    }
}
