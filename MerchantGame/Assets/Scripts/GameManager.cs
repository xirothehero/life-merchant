using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Reset();
    }

    public void Reset()
    {
        Player.Get().health = 50;
        StoreManager.Get().ClearStock();
        // TODO Clear inventory
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMenu()
    {
        Reset();
        SceneManager.LoadScene("StartMenu");
        Destroy(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Blacksmith");

    }

    public static GameManager Get()
    {
        GameManager gm = null;

        if(GameObject.FindWithTag("Managers") != null)
        {
            gm = GameObject.FindWithTag("Managers").GetComponent<GameManager>();
        }

        return gm;
    }

    public void Die()
    {
        Debug.Log("boy u ded");
    }

    public void Win()
    {
        Debug.Log("yay u win & get a life or something");
    }
}
