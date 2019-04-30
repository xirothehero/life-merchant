using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{

    public List<BaseEnemy> baseEnemies;

    public ItemBox weaponBox;

    public Image playerImage;

    public Image currentEnemyImage;
    public Text enemyHealthText;
    public Text enemyAttackText;

    public Text playerHealthText;
    public Text playerAttackText;

    public GameObject selectButtons;
    public GameObject outOfItems;

    public Color damageColor;
    public Color restColor;

    public Color restTextColor;

    Enemy currentEnemy;

    int weaponIndex = 0;

    int playerDefenseModifier = 0;

    string playerAttack = "-";

    // Start is called before the first  update
    void Start()
    {
        currentEnemy = randomEnemy();
        currentEnemyImage.sprite = currentEnemy.getSprite();
        updateItem();
        UpdatePlayerValues();
        UpdateEnemyValues();
        AudioManager.Get().PlayMusic(AudioManager.MusicClipName.BattleMusic);
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
            selectButtons.SetActive(true);
            outOfItems.SetActive(false);
        }
        else{
            selectButtons.SetActive(false);
            outOfItems.SetActive(true);
        }
    }

    public void useItem(){
        Item usedItem = Inventory.Get().GetItem(weaponIndex);
        playAttackSound(usedItem);
        applyEffects(usedItem);
        Inventory.Get().RemoveItem(usedItem);
        updateItem();
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

    void playAttackSound(Item item){
        if (item.baseItem.baseName == "Magic Mist"){
            AudioManager.Get().PlaySound(AudioManager.SoundClipName.MagicMist);
        }
        if (item.baseItem.baseName == "Sword"){
            AudioManager.Get().PlaySound(AudioManager.SoundClipName.SwordStrike);
        }
    }

    void AttackEnemy(int damage){
        setEnemyDamageColor();
        Invoke("setEnemyRestColor",0.2f);
        currentEnemy.loseHealth(damage);
        UpdateEnemyValues();
        Invoke("AttackPlayer", 0.21f);
    }
    void CheckEnemyHealth(){
        if (currentEnemy.getHealth() == 0){
            AudioManager.Get().PlaySound(AudioManager.SoundClipName.Death);
            updateItem();
            JourneyManager.Get().NextBattle();
        }
    }

    void ApplyDefenseModifier(int modifier){
        playerDefenseModifier += modifier;
    }

    void setEnemyRestColor(){
        currentEnemyImage.color = restColor;
        enemyAttackText.color = restTextColor;
        enemyHealthText.color = restTextColor;
        weaponBox.gameObject.SetActive(true);
        CheckEnemyHealth();
    }

    void setEnemyDamageColor(){
        currentEnemyImage.color = damageColor;
        enemyAttackText.color = damageColor;
        enemyHealthText.color = damageColor;
        weaponBox.gameObject.SetActive(false);
    }

    void setPlayerRestColor(){
        playerImage.color = restColor;
        playerAttackText.color = restTextColor;
        playerHealthText.color = restTextColor;
        weaponBox.gameObject.SetActive(true);
        CheckEnemyHealth();
    }

    void setPlayerDamageColor(){
        playerImage.color = damageColor;
        playerAttackText.color = damageColor;
        playerHealthText.color = damageColor;
        weaponBox.gameObject.SetActive(false);
    }

    void AttackPlayer(){
        setPlayerDamageColor();
        int health = (int) Mathf.Ceil( currentEnemy.getAttack() * Mathf.Clamp01((1 - 0.01f)*playerDefenseModifier) );
        if (!Player.Get().RemoveHealth(health)){
            Invoke("setPlayerRestColor",0.2f);
        }
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

    void Update(){
        updateItem();
    }

}
