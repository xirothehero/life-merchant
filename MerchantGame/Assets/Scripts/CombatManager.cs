using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{

    public List<BaseEnemy> baseEnemies;

    public ItemBox weaponBox;

    public Image currentEnemyImage;
    public Text enemyHealthText;
    public Text enemyAttackText;

    public Text playerHealthText;
    public Text playerAttackText;

    public GameObject selectButtons;
    public GameObject outOfItems;

    public Color damageColor;
    public Color restColor;

    Enemy currentEnemy;

    int weaponIndex = 0;

    int playerDefenseModifier = 0;

    string playerAttack = "-";

    // Start is called before the first frame update
    void Start()
    {
        currentEnemy = randomEnemy();
        currentEnemyImage.sprite = currentEnemy.getSprite();
        updateItem();
        UpdatePlayerValues();
        UpdateEnemyValues();
    }

    Enemy randomEnemy(){
        int baseEnemyIndex = Random.Range(0, baseEnemies.Count);
        Enemy enemy = baseEnemies[baseEnemyIndex].GetRandomVariant();
        return enemy;
    }

    public void nextItem(){
        weaponIndex++;
        weaponIndex %= Inventory.Get().countItems();
        updateItem();
    }

    void updateItem(){
        Item item = Inventory.Get().GetItem(weaponIndex);
        if (item != null){
            weaponBox.SetItem(Inventory.Get().GetItem(weaponIndex));
        }
        else{
            selectButtons.SetActive(false);
            outOfItems.SetActive(true);
        }
    }

    public void useItem(){
        Item usedItem = Inventory.Get().GetItem(weaponIndex);
        Inventory.Get().RemoveItem(usedItem);
    }

    void applyEffects(Item item){
        List<BaseItem.Effect> effects = item.effects();
        foreach (BaseItem.Effect effect in effects){
            switch(effect.type){
                case BaseItem.Effect.Type.Attack:
                    AttackEnemy(effect.effectValues[item.variantId]);
                    break;
                case BaseItem.Effect.Type.Defense:
                    ApplyDefenseModifier(effect.effectValues[item.variantId]);
                    break;
                default:
                    break;
            }
        }
    }

    void AttackEnemy(int damage){
        setEnemyDamageColor();
        Invoke("setEnemyRestColor",0.2f);
        int health = currentEnemy.loseHealth(damage);
        if (health == 0){
            //TODO enemy dies
        }
        UpdateEnemyValues();
    }

    void ApplyDefenseModifier(int modifier){
        playerDefenseModifier += modifier;
    }

    void setEnemyRestColor(){
        currentEnemyImage.color = restColor;
    }

    void setEnemyDamageColor(){
        currentEnemyImage.color = damageColor;
    }

    void AttackPlayer(int damage){
        int health = (int) Mathf.Ceil(damage * (1 - 0.1f*playerDefenseModifier));
        Player.Get().RemoveHealth(health);
        UpdatePlayerValues();
    }

    void UpdateEnemyValues(){
        enemyHealthText.text = currentEnemy.getHealth().ToString();
        enemyAttackText.text = currentEnemy.getAttack().ToString();
    }

    void UpdatePlayerValues(){
        playerHealthText.text = Player.Get().GetHealth().ToString();
        playerAttackText.text = playerAttack;
    }

}
