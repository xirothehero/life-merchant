using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 51)]
public class BaseItem : ScriptableObject
{

    public enum Realm { Physical, Magical }

    public Realm realm;

    public string baseName;

    public List<string> variantNames;

    public List<Sprite> variantSprites;

    public List<int> lowCosts;

    public List<int> highCosts;

    public List<Effect> effects;

    public Item GetRandomVariant()
    {
        Item item = new Item();

        item.baseItem = this;
        item.variantId = Random.Range(0, variantNames.Count);

        return item;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class Effect
    {
        // Attack = pure damage to hp
        // Defense = % dmg reductioe
        public enum Type { Attack, Defense }
        public Type type;
        public List<int> effectValues;
    }
}
