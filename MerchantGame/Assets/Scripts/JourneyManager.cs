using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JourneyManager : MonoBehaviour
{
    public int numBattles = 3;
    private int currBattle = 0;

    public string destinationSceneName;

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
        currBattle %= numBattles + 1;
        if (currBattle == numBattles){
            currBattle = 0;
            SceneManager.LoadScene(destinationSceneName);
        }
        else{
            SceneManager.LoadScene("Combat");
        }
    }

    
}
