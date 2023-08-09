using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Upgrade_Menu_Controller : MonoBehaviour
{
    public Game_Manager gameManager;
    private string GAME_OVER_TAG = "Game Over";

    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI damageCost;
    public TextMeshProUGUI rangeCost;
    public TextMeshProUGUI speedCost;
    public TextMeshProUGUI damageLvl;
    public TextMeshProUGUI rangeLvl;
    public TextMeshProUGUI speedLvl;

    public UnityEngine.UI.Button damage_button;
    public UnityEngine.UI.Button range_button;
    public UnityEngine.UI.Button speed_button;

    public Archer_Tower tower;

    public int coins = 0;
    public int levelDamage = 1, levelRange = 1, levelSpeed = 1;
    public int costDamage = 1, costRange = 1, costSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<Game_Manager>();
        levelDamage = 1;
        levelRange = 1;
        levelSpeed = 1;
        costDamage = 1;
        costRange = 1;
        costSpeed = 1;
        coins = 0;

        coinCount.text = "X " + coins;

        damageCost.text = "Coin: " + costDamage;
        rangeCost.text = "Coin: " + costRange;
        speedCost.text = "Coin: " + costSpeed;

        damageLvl.text = "Damage: Lv " + levelDamage;
        rangeLvl.text = "Range: Lv " + levelRange;
        speedLvl.text = "Speed: Lv " + levelSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        updateText();
    }
    
    public void updateText()
    {
        coinCount.text = "X " + coins;

        damageCost.text = "Coin: " + costDamage;
        rangeCost.text = "Coin: " + costRange;
        speedCost.text = "Coin: " + costSpeed;

        if(levelDamage == 22)
        {
            damageLvl.text = "Damage: Max";
            damage_button.interactable = false;
        }
        else
        {
            damageLvl.text = "Damage: Lv " + levelDamage;
        }

        if (levelRange == 6)
        {
            rangeLvl.text = "Range: Max";
            range_button.interactable = false;  
        }
        else
        {
            rangeLvl.text = "Range: Lv " + levelRange;
        }

        if (levelSpeed == 3)
        {
            speedLvl.text = "Speed: Max";
            speed_button.interactable = false;
        }
        else
        {
            speedLvl.text = "Speed: Lv " + levelSpeed;
        }     
    }

    public void upgradeDamage()
    {
        if(levelDamage < 22 && coins >= costDamage)
        {
            tower.GetComponent<Archer_Tower>().upgradeDamage();
            levelDamage++;
            coins -= costDamage;
            costDamage = costDamage * 2;
        }
    }

    public void upgradeRange()
    {
        if(levelRange < 6 && coins >= costRange)
        {
            tower.GetComponent<Archer_Tower>().upgradeRange();
            levelRange++;
            coins -= costRange;
            costRange = costRange * 2;
        }
    }

    public void upgradeSpeed()
    {
        if (levelSpeed < 3 && coins >= costSpeed)
        {
            tower.GetComponent<Archer_Tower>().upgradeSpeed();
            levelSpeed++;
            coins -= costSpeed;
            costSpeed = costSpeed * 2;
        }
    }

    public void coinUpdate(int coin)
    {
        coins += coin;
    }

    public void gameOver(int i)
    {
        if(i == 0)
        {
            gameManager.coinCount(0);
            //load gameover scene
            SceneManager.LoadScene(GAME_OVER_TAG);
        }
        else
        {
            gameManager.coinCount(coins);
            //load gameover scene
            SceneManager.LoadScene(GAME_OVER_TAG);
        } 
    } 
}
