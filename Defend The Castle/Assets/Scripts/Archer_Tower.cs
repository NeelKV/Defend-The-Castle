using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Archer_Tower : MonoBehaviour
{
    private Vector3 projectileShootPos;
    private float range;
    private Arrow_Behavior AB;

    [SerializeField]
    private GameObject arrowRef;
    

    private void Awake()
    {
        projectileShootPos = transform.Find("Arrow_Launch_Pos").position;
        range = 400f;
        AB = GetComponent<Arrow_Behavior>();

    }

    private void shoot(Vector3 targetPosition)
    {
        Debug.Log("shoot called");
        GameObject projectileArrow = Instantiate(arrowRef);
        projectileArrow.transform.position = projectileShootPos;
        projectileArrow.GetComponent<Arrow_Behavior>().Setup(targetPosition);
        
    }

    private void Update()
    {
        Enemy enemy = GetClosestEnemy();
        if (enemy != null)
        {   //enemy in range
            shoot(enemy.transform.position);
        }
    }

    private Enemy GetClosestEnemy()
    {
        return Spawner.GetClosestEnemy(this.transform.position, range);
    }

}

