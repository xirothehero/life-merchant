using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Event_Scene : EventBase
{

    public string sceneName;

    public override void Trigger()
    {
        done = false;
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(sceneName);
        done = true;
    }
}
