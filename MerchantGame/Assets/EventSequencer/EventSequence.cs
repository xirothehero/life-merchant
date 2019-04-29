using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSequence : MonoBehaviour
{
    public string title;
    public List<EventBase> events;

    public int idx = 0;

    public bool auto = false;

    // Start is called before the first frame update
    void Start()
    {
        Prep();
    }


    // Update is called once per frame
    void Update()
    {
        if(auto)
        {
            if (SequenceDone())
            {
                auto = false;
                EndSequence();
            }
            else if (EventDone())
            {
                NextEvent();
            }
        }

    }

    // Allow the sequencer to handle transitions
    public void StartSequenceAuto()
    {
        auto = true;
        StartSequence();
    }

    /* Do things manually------------*/

    public void StartSequence()
    {
        Debug.Log("starting sequence");
        Prep();
        idx = 0;
        StartEvent();
    }

    public void EndSequence()
    {
        Debug.Log("Finished sequence: " + title);
    }

    public void StartEvent()
    {
        CurrentEvent().Trigger();
    }

    // Must check if sequence is done or not before calling!!
    public void NextEvent()
    {
        idx++;
        StartEvent();
    }

    public bool EventDone()
    {
        return CurrentEvent().Done();
    }

    public bool SequenceDone()
    {
        return EventDone() && (idx + 1 >= events.Count);
    }

    public EventBase CurrentEvent()
    {
        return events[idx];
    }
    
    // Call to ensure populated first
    void Prep()
    {
        idx = 0;
        events.Clear();
        EventBase[] attachedEvents = GetComponents<EventBase>();
        foreach (EventBase ev in attachedEvents)
        {
            events.Add(ev);
        }
    }
}
