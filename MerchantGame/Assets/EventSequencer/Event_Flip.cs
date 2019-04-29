using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Flip : EventBase
{

    public override void Trigger()
    {
        done = false;
        StartCoroutine(Flip());
    }

    IEnumerator Flip()
    {
        yield return new WaitForSeconds(waitTime);

        target.GetComponent<SpriteRenderer>().flipX = !target.GetComponent<SpriteRenderer>().flipX;
        done = true;
    }
}
