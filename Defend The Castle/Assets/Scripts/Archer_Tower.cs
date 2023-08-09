using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Archer_Tower : MonoBehaviour
{
    [SerializeField]
    private float towerRange = 4f;
    
    [SerializeField]
    private float currentDamage = 0.9f;
    
    [SerializeField]
    private float shootInterval = 2f;
    private float lastShootTime = 0f;

    private GameObject closestEnemy;
    private GameObject rangeCircle;
    
    public TextMeshProUGUI tower_Health;
    public int health;


    private void Start()
    {
        currentDamage = 1;
        shootInterval = 2f;
        lastShootTime = 0f;
        towerRange = 4f;
        health = 10;
        rangeCircle = GameObject.Find("Range");

    }

    private void Update()
    {
        rangeCircle.transform.localScale = Vector3.one * towerRange * 2f;
        tower_Health.text = "Health: " + health;
        FindClosestEnemy();

        if (closestEnemy != null && Time.time - lastShootTime > shootInterval)
        {
            damageEnemy(closestEnemy.GetComponent<Enemy>());
            lastShootTime = Time.time;
        }
    }

    private void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance && distanceToEnemy <= towerRange)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
    }

    private void damageEnemy(Enemy enemy)
    {
        enemy.takeDamage(currentDamage);
    }

    public void takeDamage(int damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            GameObject.Find("Upgrade_Menu").GetComponent<Upgrade_Menu_Controller>().gameOver(0);
        }
    }

    public void upgradeDamage()
    {
        if (currentDamage < 3)
        {
            currentDamage = currentDamage + 0.2f;
        }
    }

    public void upgradeRange()
    {
        if (towerRange < 7f)
        {
            towerRange = towerRange + 0.5f;
        }
    }

    public void upgradeSpeed()
    {
        if(shootInterval > 0.5f)
        {
            shootInterval = shootInterval - 0.5f;
        }
    }

}

