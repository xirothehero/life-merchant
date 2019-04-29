using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy", order = 52)]
public class BaseEnemy : ScriptableObject
{
    public string baseName;

    public List<string> variantNames;

    public List<Sprite> sprites;

    public List<int> lowHealths;

    public List<int> highHealths;

    public List<int> lowAttacks;

    public List<int> highAttacks;

    public Enemy GetRandomVariant()
    {
        Enemy enemy = new Enemy();

        enemy.baseEnemy = this;
        enemy.variantId = Random.Range(0, variantNames.Count);
        enemy.setCurrentHealth(Random.Range(lowHealths[enemy.variantId], highHealths[enemy.variantId] + 1));
        enemy.setAttack(Random.Range(lowAttacks[enemy.variantId], highAttacks[enemy.variantId] + 1));
        return enemy;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
