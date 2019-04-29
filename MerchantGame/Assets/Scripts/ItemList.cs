using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{

    public GameObject listItemTemplate;

    private List<GameObject> items;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();

        if (items.Count > 0){
            foreach(GameObject item in items){
                Destroy(item);
            }
            items.Clear();
        }

        for (int i = 0; i < 10; i++){
            GameObject button = Instantiate(listItemTemplate);
            button.SetActive(true);
            button.GetComponent<ItemSelect>().SetInfo();
            button.transform.SetParent(listItemTemplate.transform.parent, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
