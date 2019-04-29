using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{

    public BaseEnemy baseEnemy;
    public int variantId = 0;

    private int currentHealth;
    private int attack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCurrentHealth(int health){
        currentHealth = health;
    }

    public int loseHealth(int health){
        currentHealth -= health;
        currentHealth = (currentHealth < 0) ? 0 : currentHealth;
        return currentHealth;
    }

    public int getHealth(){
        return currentHealth;
    }

    public int getAttack(){
        return attack;
    }

    public void setAttack(int attack){
        this.attack = attack;
    }

    public Sprite getSprite(){
        return baseEnemy.sprites[variantId];
    }

}
