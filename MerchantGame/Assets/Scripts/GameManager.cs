using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
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

    public static GameManager Get()
    {
        GameManager gm = GameObject.FindWithTag("Managers").GetComponent<GameManager>();

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
