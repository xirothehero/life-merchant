using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JourneyManager : MonoBehaviour
{
    public int numBattles = 3;
    public int currBattle = 0;

    public string[] destinationSceneNames;
    public int currentDestination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static JourneyManager Get()
    {
        JourneyManager jm = null;

        if(GameObject.FindWithTag("Managers") != null)
        {
            jm = GameObject.FindWithTag("Managers").GetComponent<JourneyManager>();
        }

        return jm;
    }

    public void NextBattle(){
        currBattle++;
        currBattle %= numBattles;
        if (currBattle == numBattles - 1){
            currentDestination++;
            currentDestination %= destinationSceneNames.Length;
            SceneManager.LoadScene(destinationSceneNames[currentDestination]);
        }
        else{
            SceneManager.LoadScene("Combat");
        }
    }

    
}
